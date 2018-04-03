using System;
using Terraria;

namespace TerrariaApi.Server
{
	public abstract class TerrariaPlugin : IDisposable
	{
		///<summary>
		/// The plugin's name. This is used for display purposes and secondary ordering when loading. 
		/// See <see cref="Order"/> for more information.
		///</summary>
		public virtual string Name
		{
			get
			{
				return "None";
			}
		}
		
		///<summary>
		/// The plugin's version. This is used for display purposes.
		///</summary>
		public virtual Version Version
		{
			get
			{
				return new Version(1, 0);
			}
		}
		
		///<summary>
		/// The plugin's author. This is used for display purposes.
		///</summary>
		public virtual string Author
		{
			get
			{
				return "None";
			}
		}
		
		///<summary>
		/// The plugin's description. This is used for display purposes.
		///</summary>
		public virtual string Description
		{
			get
			{
				return "None";
			}
		}
		
		///<summary>
		/// Whether or not the plugin is enabled.
		///</summary>
		public virtual bool Enabled
		{
			get;
			set;
		}
		
		///<summary>
		/// The plugin's order. This represents load priority.
		/// Plugins are sorted first based on order, then on name where conflicts occur.
		/// A lower order represents a higher load priority - I.E., order 1 is loaded before order 5.
		/// This value may be negative.
		/// The default plugin constructor will set order to 1.
		///</summary>
		public int Order
		{
			get;
			set;
		}
		
		///<summary>
		/// Deprecated - this value is never used
		///</summary>
		public virtual string UpdateURL
		{
			get
			{
				return "";
			}
		}
		
		///<summary>
		/// Reference to Terraria's <see cref="Main"/> class containing server state.
		///</summary>
		protected Main Game
		{
			get;
			private set;
		}

		///<summary>
		/// Instantiates a new instance of the plugin with the given server state.
		/// Sets <see cref="Order"/> to 1.
		///</summary>
		protected TerrariaPlugin(Main game)
		{
			this.Order = 1;
			this.Game = game;
		}

		///<summary>
		/// Deconstructor. Implements the Dispose pattern.
		///</summary>
		~TerrariaPlugin()
		{
			this.Dispose(false);
		}
		
		///<summary>
		/// Implements the Dispose pattern. Disposes the plugin
		///</summary>
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}
		
		///<summary>
		/// Implements the Dispose pattern. Release managed resources here.
		///</summary>
		protected virtual void Dispose(bool disposing)
		{
		}

		///<summary>
		/// Invoked after the plugin is constructed. Initialization logic should occur here.
		///</summary>
		public abstract void Initialize();
	}
}
