using System;
using TerrariaApi.Server;

namespace TerrariaApi.Server
{
	public interface IPluginContainer : IDisposable
	{
		TerrariaPlugin Plugin { get; }
		bool Initialized { get; }
		bool Dll { get; set; }
		void Initialize();
		void DeInitialize();
	}
}
