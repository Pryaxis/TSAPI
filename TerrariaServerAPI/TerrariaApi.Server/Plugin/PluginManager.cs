using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using NLog;

namespace TerrariaApi.Server
{
	public class PluginManager : DisposableObject
	{
		public IReadOnlyList<IPluginLoader> PluginLoaders => pluginLoaders;
		public IReadOnlyList<IPlugin> Plugins => plugins;
		public bool AllLoaded => pluginLoaders.All(l => l.IsLoaded);

		private List<IPluginLoader> pluginLoaders;
		private List<IPlugin> plugins;

		private static readonly Logger Log = LogManager.GetLogger(nameof(PluginManager));

		public PluginManager()
		{
			pluginLoaders = new List<IPluginLoader>();
			plugins = new List<IPlugin>();
		}

		public void LoadPlugins()
		{
			foreach (var loader in pluginLoaders)
			{
				if (!loader.IsLoaded)
				{
					try
					{
						Log.Info($"Try loading plugins with loader {loader.GetType().FullName}");
						plugins.AddRange(loader.LoadPlugins());
					}
					catch (Exception e)
					{
						Log.Error($"Error when loading plugins: {e}");
					}
				}
			}
		}

		public void InitializeAllPlugins()
		{
			foreach (var p in plugins)
			{
				p.Init();
			}
		}

		public void UnloadAllPlugins()
		{
			//TODO: Implement this
		}

		public void RegisterPluginLoader([NotNull]IPluginLoader pluginLoader, bool loadImmediately = false)
		{
			if(pluginLoader is null) throw new ArgumentNullException(nameof(pluginLoader));
			pluginLoaders.Add(pluginLoader);
			Log.Debug($"New plugin loader registered. Type: '{pluginLoader.GetType().FullName}'");
			if (!pluginLoader.IsLoaded && loadImmediately)
			{
				Log.Debug($"Begin loading plugins with loader {pluginLoader.GetType().FullName}");
				var loaded = pluginLoader.LoadPlugins();
				foreach (var plugin in loaded)
				{
					plugin.Init();
				}
				plugins.AddRange(loaded);
			}
		}

		protected override void Dispose(bool canDisposeManaged)
		{
			DisposeUnmanaged();
			if (canDisposeManaged)
			{
				foreach (var loader in pluginLoaders)
				{
					loader.Dispose();
				}
				DisposeManaged();
			}
		}
	}
}
