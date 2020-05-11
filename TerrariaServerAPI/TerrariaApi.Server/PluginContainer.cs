using System;
#if NETCOREAPP
using TerrariaServerAPI.TerrariaApi.Server;
#endif

namespace TerrariaApi.Server
{
	public class PluginContainer : IDisposable
	{
		public TerrariaPlugin Plugin
		{
			get;
			protected set;
		}
		public bool Initialized
		{
			get;
			protected set;
		}
		public bool Dll
		{
			get;
			set;
		}

#if NETCOREAPP
		public PluginLoadContext Context { get; }
#endif

		public PluginContainer(TerrariaPlugin plugin
#if NETCOREAPP
			, PluginLoadContext context): this(plugin, true, context)
#else
			): this(plugin, true)
#endif
		{
		}

		public PluginContainer(TerrariaPlugin plugin, bool dll
#if NETCOREAPP
			, PluginLoadContext context
#endif
			)
		{
			this.Plugin = plugin;
			this.Initialized = false;
			this.Dll = dll;
#if NETCOREAPP
			this.Context = context ?? throw new ArgumentNullException(nameof(context));
#endif
		}

		public void Initialize()
		{
			this.Plugin.Initialize();
			this.Initialized = true;
		}

		public void DeInitialize()
		{
			this.Initialized = false;
		}

		public void Dispose()
		{
			this.Plugin.Dispose();
		}
	}
}
