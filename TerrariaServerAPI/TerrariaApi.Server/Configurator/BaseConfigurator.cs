namespace TerrariaApi.Configurator;

/// <summary>
/// Describes a class that will provide hosted service configuration
/// </summary>
public abstract class BaseConfigurator
{
	/// <summary>
	/// The priority of this configurator. Higher priority configurators will be invoked earlier.
	/// </summary>
	public int Priority { get; protected set; }

	/// <summary>
	/// Empty default constructor. All configurators must be constructable with no arguments.
	/// </summary>
	protected BaseConfigurator() { }
}
