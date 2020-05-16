using System;
using System.Linq;
using OTAPI.Shims.TShock;
using TerrariaApi.Server;

namespace TerrariaServer
{
	class Program
	{
		static void Main(string[] args)
		{
			ServerApi.PluginManager.RegisterPluginLoader(
				new DefaultPluginLoader("ServerPlugins", args.Any(a => a == "-ignoreversion")));

			Launch.Start(args);
		}

	}
}
