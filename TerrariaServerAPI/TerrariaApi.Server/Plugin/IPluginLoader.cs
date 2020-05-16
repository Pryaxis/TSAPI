using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace TerrariaApi.Server
{
	public interface IPluginLoader : IDisposable
	{
		bool IsLoaded { get; }
		IReadOnlyList<IPlugin> LoadedPlugin { get; }
		List<IPlugin> LoadPlugins(bool reload = false);
		void UnloadPlugin([NotNull]IPlugin plugin);
		void ReloadPlugin([NotNull]IPlugin plugin);
	}
}
