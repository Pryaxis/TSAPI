using System;
using NLog;
using Terraria;

namespace TerrariaApi.Server
{
	public abstract class TerrariaPlugin : DisposableObject, IPlugin
	{
		public virtual string Name => "None";
		public virtual string Author => "None";
		public virtual string Description => "None";
		public virtual Version Version => new Version(1, 0);
		public int Order { get; set; } = 1;
		public virtual bool Enabled { get; set; }
		public bool Initialized { get; protected set; }
		public IPluginLoader Loader { get; set; }

		protected Logger Log;

		///<summary>
		/// Instantiates a new instance of the plugin with the given server state.
		/// Sets <see cref="Order"/> to 1.
		///</summary>
		protected TerrariaPlugin(Main game) { }

		public virtual void Init()
		{
			if (Initialized)
			{
				Log.Error($"Don't initialize a plugin twice!");
				return;
			}

			try
			{
				Log = LogManager.GetLogger(Name);
				Initialize();
				Initialized = true;
			}
			catch (Exception e)
			{
				Log.Error($"Error on initialization: {e}");
			}
		}

		// Should rename to OnInit and be protected when we can discard backward compatibility
		public abstract void Initialize();


	}
}
