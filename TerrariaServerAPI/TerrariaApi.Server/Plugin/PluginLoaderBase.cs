using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using NLog;

namespace TerrariaApi.Server
{
	public abstract class PluginLoaderBase : DisposableObject, IPluginLoader
	{
		public bool IsLoaded { get; protected set; }

		public IReadOnlyList<IPlugin> LoadedPlugin => loadedPlugins;

		public abstract List<IPlugin> LoadPlugins(bool reload = false);

		protected string PluginDirPath;

		protected abstract Logger Log { get; }

		protected List<IPlugin> loadedPlugins;

		protected PluginLoaderBase([NotNull]string pluginDirPath)
		{
			PluginDirPath = pluginDirPath ?? throw new ArgumentNullException(nameof(pluginDirPath));

		}

		public abstract void UnloadPlugin(IPlugin plugin);

		public abstract void ReloadPlugin(IPlugin plugin);

		protected List<FileInfo> FindPluginFiles([NotNull]string dirPath, params string[] extNames)
		{
			if(dirPath is null) throw new ArgumentNullException(nameof(dirPath));
			DirectoryInfo dir;
			try
			{
				dir = new DirectoryInfo(dirPath);
			}
			catch (Exception e)
			{
				throw new ArgumentException($"Can't find plugins in directory: {dirPath}", e);
			}

			if (extNames is null)
				return FilterIgnoredPluginFiles(dirPath, dir.GetFiles());

			var result = new List<FileInfo>();
			foreach (var extName in extNames)
			{
				result.AddRange(dir.GetFiles($"*.{extName}"));
			}

			return FilterIgnoredPluginFiles(dirPath, result);
		}

		protected List<FileInfo> FilterIgnoredPluginFiles([NotNull]string dirPath, [NotNull]ICollection<FileInfo> files)
		{
			const string ignoredPluginsFileName = "ignoredplugins.txt";
			if(dirPath is null) throw new ArgumentNullException(nameof(dirPath));
			if(files is null) throw new ArgumentNullException(nameof(files));
			var filePath = Path.Combine(dirPath, ignoredPluginsFileName);
			try
			{
				if (!File.Exists(filePath))
					File.Create(filePath);
				var ignored = File.ReadAllLines(filePath);
				return files.Where(f => !ignored.Contains(f.Name)).ToList();
			}
			catch (Exception e)
			{
				Log.Warn($"Error when filtering ignored plugins: {e}");
				return files.ToList();
			}
		}

		protected override void Dispose(bool canDisposeManaged)
		{
			DisposeUnmanaged();
			if (canDisposeManaged)
			{
				foreach (var plugin in LoadedPlugin)
				{
					plugin.Dispose();
				}
				DisposeManaged();
			}
		}
	}
}
