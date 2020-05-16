using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using JetBrains.Annotations;
using NLog;
using Terraria;

namespace TerrariaApi.Server
{
	public class DefaultPluginLoader : PluginLoaderBase
	{
		public bool IgnoreVersion { get; set; }

		protected Dictionary<string, Assembly> loadedAssemblies = new Dictionary<string, Assembly>();

		protected override Logger Log => classLogger;

		private static Logger classLogger = LogManager.GetLogger(nameof(DefaultPluginLoader));

		public DefaultPluginLoader([NotNull]string pluginDirPath, bool ignoreVersion = false)
			: base(pluginDirPath)
		{
			IgnoreVersion = ignoreVersion;
			AppDomain.CurrentDomain.AssemblyResolve += AssemblyResolveHandler;
			if (!Directory.Exists(pluginDirPath))
				Directory.CreateDirectory(pluginDirPath);
		}

		[NotNull]
		public override List<IPlugin> LoadPlugins(bool reload = false)
		{
			var plugins = new List<IPlugin>();
			if (IsLoaded)
			{
				if (!reload)
				{
					Log.Warn($"Can't load plugins because this plugin is loaded.");
					return plugins;
				}

				foreach (var plugin in loadedPlugins)
				{
					UnloadPlugin(plugin);
				}
			}
			try
			{
				foreach (var fileInfo in FindPluginFiles(PluginDirPath,
					"dll", "dll-plugin"))
				{
					var loaded = LoadPluginFromFile(fileInfo);
					if(loaded != null)
						plugins.AddRange(loaded);
				}
			}
			finally
			{
				IsLoaded = true;
			}

			loadedPlugins = (from x in plugins
				orderby x.Order, x.Name
				select x).ToList();
			return loadedPlugins;
		}

		protected virtual List<IPlugin> LoadPluginFromFile(FileInfo fileInfo)
		{
			Assembly assembly;
			try
			{
				assembly = Assembly.Load(File.ReadAllBytes(fileInfo.FullName));
				return LoadPluginInternal(assembly);
			}
			catch(BadImageFormatException) { }
			catch (Exception e)
			{
				Log.Error($"Error when loading plugin file '{fileInfo.FullName}'\nError: {e}");
			}
			return null;
		}

		protected virtual List<IPlugin> LoadPluginInternal(Assembly asm)
		{
			var result = new List<IPlugin>();

			loadedAssemblies.Add(asm.GetName().Name, asm);
			if (!ValidatePlugin(asm))
			{
				Log.Debug($"Not a plugin: {asm.FullName}");
				return result;
			}
			foreach (var type in asm.GetExportedTypes())
			{
				if (!type.IsSubclassOf(typeof(TerrariaPlugin)) || !type.IsPublic || type.IsAbstract)
					continue;
				if (!IgnoreVersion && type.GetCustomAttribute<ApiVersionAttribute>() is ApiVersionAttribute attribute)
				{
					var apiVersion = attribute.ApiVersion;
					if (apiVersion.Major != ServerApi.ApiVersion.Major
					    || apiVersion.Minor != ServerApi.ApiVersion.Minor)
					{
						Log.Warn(
							$"Plugin \"{type.FullName}\" is designed for a different Server API version ({apiVersion.ToString(2)}) and was ignored.");
						continue;
					}
				}
				try
				{
					var plugin = (TerrariaPlugin) Activator.CreateInstance(type, Main.instance);
					result.Add(plugin);
					Log.Info($"Plugin {plugin.Name} v{plugin.Version} (by {plugin.Author}) loaded.");
				}
				catch (Exception ex)
				{
					Log.Error($"Error when creating plugin instance.\n" +
					          $"PluginType: {type.FullName}\n" +
					          $"Error: {ex}");
				}
			}
			return result;
		}
		protected virtual bool ValidatePlugin(Assembly asm)
		{
			var requiredReference = typeof(ServerApi).Assembly.GetName();
			var references = asm.GetReferencedAssemblies();
			if (references.Contains(requiredReference)
			    // Backward compatibility
				|| references.Any(r => r.Name == "TerrariaServer"))
				return true;
			return false;
		}

		public override void UnloadPlugin(IPlugin plugin)
		{
			try
			{
				//TODO: Implement this
			}
			catch(Exception){}
		}

		public override void ReloadPlugin(IPlugin plugin)
		{
			//TODO: Implement this
		}

		private Assembly AssemblyResolveHandler(object sender, ResolveEventArgs args)
		{
			try
			{
				var asmName = new AssemblyName(args.Name);
				string path = Path.Combine(PluginDirPath, $"{asmName.Name}.dll");
				if (File.Exists(path))
				{
					Assembly assembly;
					if (!loadedAssemblies.TryGetValue(asmName.Name, out assembly))
					{
						assembly = Assembly.Load(File.ReadAllBytes(path));
						loadedAssemblies.Add(asmName.Name, assembly);
					}
					return assembly;
				}
			}
			catch (Exception) { }
			return null;
		}

		protected override void DisposeUnmanaged()
		{
			AppDomain.CurrentDomain.AssemblyResolve -= AssemblyResolveHandler;
		}
	}
}
