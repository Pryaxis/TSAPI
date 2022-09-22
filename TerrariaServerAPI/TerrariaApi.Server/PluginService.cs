namespace TerrariaApi.Server;

/// <summary>
/// Describes a class that will provide a service that can be used with dependency injection
/// </summary>
public abstract class PluginService
{
	/// <summary>
	/// Priority of this service. Higher priority services will be initialized sooner. 
	/// Defaults to 0.
	/// <para/>
	/// Note that this will not affect the order in which services are constructed,
	/// only the order in which each plugin's <see cref="Start"/> is called
	/// </summary>
	public int Priority { get; protected set; } = 0;

	/// <summary>
	/// Called when the server is ready for plugins to begin doing things
	/// </summary>
	public void Start() { }
}
