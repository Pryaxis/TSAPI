using System.Collections.Generic;

namespace TerrariaApi.Server
{
	public interface IPluginLoader
	{
		ICollection<IPluginContainer> LoadPlugins();

		void UnloadPlugin(IPluginContainer plugin);
	}
}
