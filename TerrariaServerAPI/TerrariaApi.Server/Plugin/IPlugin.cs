using System;

namespace TerrariaApi.Server
{
	public interface IPlugin : IDisposable
	{
		///<summary>
		/// The plugin's name. This is used for display purposes and secondary ordering when loading.
		/// See <see cref="Order"/> for more information.
		///</summary>
		string Name { get; }
		///<summary>
		/// The plugin's author. This is used for display purposes.
		///</summary>
		string Author { get; }
		///<summary>
		/// The plugin's description. This is used for display purposes.
		///</summary>
		string Description { get; }
		///<summary>
		/// The plugin's version. This is used for display purposes.
		///</summary>
		Version Version { get; }
		///<summary>
		/// The plugin's order. This represents load priority.
		/// Plugins are sorted first based on order, then on name where conflicts occur.
		/// A lower order represents a higher load priority - I.E., order 1 is loaded before order 5.
		/// This value may be negative.
		/// The default plugin constructor will set order to 1.
		///</summary>
		int Order { get; }
		///<summary>
		/// Whether or not the plugin is enabled.
		///</summary>
		bool Enabled { get; set; }
		bool Initialized { get; }
		/// <summary>
		/// The loader which loads this plugin
		/// </summary>
		IPluginLoader Loader { get; }
		///<summary>
		/// Invoked after the plugin is constructed. Initialization logic should occur here.
		///</summary>
		void Init();
	}
}
