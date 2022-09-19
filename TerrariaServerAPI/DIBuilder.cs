using System.Reflection;
using TerrariaApi.Configurator;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace TerrariaApi.Server;

static class DIBuilder
{
	const string PLUGIN_PATH = "plugins";

	internal static IHostBuilder ConfigureHost(string[] args)
	{
		Dictionary<string, Assembly> loadedAssemblies = ResolveAssemblies(PLUGIN_PATH);
		IEnumerable<Type> exportedTypes = loadedAssemblies.SelectMany(kvp => kvp.Value.GetExportedTypes());

		// Add initial configuration to the host
		IHostBuilder hostBuilder = Host.CreateDefaultBuilder()
			.ConfigureHostConfiguration(conf => conf        // Add configuration for the host.
				.AddCommandLine(args)                       // This need only be enough to get things up and running.
				.AddEnvironmentVariables(prefix: "TSAPI_")  // All other config should be part of 'app configuration'
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

		// Run each configurator, passing the different requirements based on configurator type
		foreach (BaseConfigurator configurator in configurators)
		{
			switch (configurator)
			{
				case ServiceConfigurator svc:
					hostBuilder.ConfigureServices((hostContext, services) => svc.Configure(hostContext, services));
					break;
				case ConfigConfigurator cfg:
					hostBuilder.ConfigureAppConfiguration((hostContext, configBuilder) => cfg.Configure(hostContext, configBuilder));
					break;
				case LoggingConfigurator log:
					hostBuilder.ConfigureLogging((hostContext, logBuilder) => log.Configure(hostContext, logBuilder));
					break;
				default:
					break;
			};
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
			string path = Path.Combine(PLUGIN_PATH, fileName + ".dll");

			if (File.Exists(path))
			{
				if (!loadedAssemblies.TryGetValue(fileName, out Assembly? asm))
				{
					asm = LoadAssembly(path);
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

		if (asm.GetExportedTypes().Any(t => t.IsSubclassOf(typeof(PluginService))))
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
		return exportedTypes.Where(type => type.IsSubclassOf(typeof(BaseConfigurator)))
							.Distinct();
	}
}
