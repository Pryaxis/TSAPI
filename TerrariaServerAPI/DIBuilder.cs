using System.Reflection;
using TerrariaApi.Configurator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace TerrariaApi.Server;

/// <summary>
/// Helper class responsible for creating the DI container and priming it with services and configuration.
/// </summary>
static class DIBuilder
{
	/// <summary>
	/// Default root directory name from which plugins will be loaded.
	/// </summary>
	const string DEFAULT_PLUGIN_ROOT = "plugins";

	internal static IHostBuilder ConfigureHost(string[] args)
	{
		// Create initial host configuration, reading values from the commandline and environment variables.
		// This enables immediate overriding of the Plugins root directory
		IConfiguration hostConfiguration = new ConfigurationBuilder()
			.AddEnvironmentVariables(prefix: "TSAPI_")
			.AddCommandLine(args)
			.Build();

		// The plugin path can be defined through an environment variable or on the commandline.
		// To use an environment variable, set a variable named TSAPI_PLUGINS__ROOT with an *unquoted* directory value. Eg export TSAPI_PLUGINS__ROOT=~/my tshock dir/plugins
		// To use a commandline variable, pass the --<key> <value> option to the command. Eg dotnet run --Plugins:Root "~/my tshock dir/plugins"
		string pluginPath = hostConfiguration.GetSection("Plugins:Root").Value ?? Path.Combine(AppContext.BaseDirectory, DEFAULT_PLUGIN_ROOT);
		Dictionary<string, Assembly> loadedAssemblies = ResolveAssemblies(pluginPath);
		IEnumerable<Type> exportedTypes = loadedAssemblies.SelectMany(kvp => kvp.Value.GetExportedTypes())
														  .Concat(typeof(DIBuilder).Assembly.GetExportedTypes());

		// Add initial configuration to the host
		IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
			.ConfigureHostConfiguration(conf => conf
				.AddConfiguration(hostConfiguration) // Generate host configuration using the configuration built earlier
			)
			.ConfigureLogging(conf => conf // Remove default logging providers & supply our own basic console logger
				.ClearProviders()
				.AddSimpleConsole(opts =>
				{
					opts.ColorBehavior = LoggerColorBehavior.Enabled;
					opts.SingleLine = true;
					opts.IncludeScopes = true;
					opts.TimestampFormat = "[dd/MM/yyyy HH:mm:ss.fff] ";
				})
			);

		// Create configurator instances.
		IEnumerable<BaseConfigurator> configurators =
			from configurator in (
				from type in GetExportedConfigurators(exportedTypes)
				select (BaseConfigurator?)Activator.CreateInstance(type)
			)
			where configurator is not null
			orderby configurator.Priority descending
			select configurator;

		// Run each configurator, passing the different requirements based on configurator type.
		// All config configurators are run first, such that all configuration is available for the log configurators.
		// All log configurators are run second, such that all logging is configured before services are loaded.
		// All service configurators are run last, such that all configuration and logging is available to them.
		foreach (ConfigConfigurator cfg in configurators.Where(configurator => configurator is ConfigConfigurator))
		{
			hostBuilder.ConfigureAppConfiguration((hostContext, configBuilder) => cfg.Configure(hostContext, configBuilder, args));
		}
		foreach (LoggingConfigurator log in configurators.Where(configurator => configurator is LoggingConfigurator))
		{
			hostBuilder.ConfigureLogging((hostContext, logBuilder) => log.Configure(hostContext, logBuilder, args));
		}
		foreach (ServiceConfigurator svc in configurators.Where(configurator => configurator is ServiceConfigurator))
		{
			hostBuilder.ConfigureServices((hostContext, services) => svc.Configure(hostContext, services, args));
		}

		// Collect all plugin service types & register them with the DI container
		IEnumerable<Type> pluginServiceTypes = GetExportedServices(exportedTypes);
		foreach (Type pluginServiceType in pluginServiceTypes)
		{
			hostBuilder.ConfigureServices(services => services.AddPluginService(pluginServiceType));
		}

		return hostBuilder;
	}

	static Dictionary<string, Assembly> ResolveAssemblies(string path)
	{
		Dictionary<string, Assembly> loadedAssemblies = new();
		Directory.CreateDirectory(path);

		AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
		{
			string fileName = args.Name.Split(',')[0];
			string filePath = Path.Combine(path, fileName + ".dll");

			if (File.Exists(filePath))
			{
				if (!loadedAssemblies.TryGetValue(fileName, out Assembly? asm))
				{
					asm = LoadAssembly(filePath);
				}
				return asm;
			}

			return null;
		};

		IList<FileInfo> fileInfos = new DirectoryInfo(path).GetFiles("*.dll");
		foreach (FileInfo fileInfo in fileInfos)
		{
			string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(fileInfo.FullName);
			if (!loadedAssemblies.ContainsKey(fileNameWithoutExtension))
			{
				Assembly? asm = LoadAssembly(fileInfo.FullName);
				if (asm != null)
				{
					loadedAssemblies.Add(fileNameWithoutExtension, asm);
				}
			}
		}

		return loadedAssemblies;
	}

	static Assembly? LoadAssembly(String path)
	{
		Assembly asm = Assembly.Load(File.ReadAllBytes(path));

		if (asm.GetExportedTypes().Any(t => t.IsSubclassOf(typeof(PluginService))
			// and allow configurational assemblies. for example, TShockCommands, depends on TShockAPI and only implements ICommandService.
			|| t.IsSubclassOf(typeof(BaseConfigurator))
		))
		{
			return asm;
		}

		return null;
	}

	static IEnumerable<Type> GetExportedServices(IEnumerable<Type> exportedTypes)
	{
		return exportedTypes.Where(type => type.IsSubclassOf(typeof(PluginService)))
							.Distinct();
	}

	static IEnumerable<Type> GetExportedConfigurators(IEnumerable<Type> exportedTypes)
	{
		return exportedTypes.Where(type => type.IsSubclassOf(typeof(BaseConfigurator)) && !type.IsAbstract)
							.Distinct();
	}
}
