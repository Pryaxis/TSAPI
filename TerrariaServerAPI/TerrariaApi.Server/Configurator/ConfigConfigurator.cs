using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace TerrariaApi.Configurator;

/// <summary>
/// Describes a class that will provide additional configuration for application configurations
/// </summary>
public abstract class ConfigConfigurator : BaseConfigurator
{
	/// <summary>
	/// Configure the given configuration builder.
	/// This can be used to add new configuration sections, files, etc.
	/// Correctly bound configuration can be used with dependency injection.
	/// <para/>
	/// For more information read the .NET Configuration documentation:
	/// <seealso cref="https://docs.microsoft.com/en-us/dotnet/core/extensions/configuration"/>
	/// </summary>
	/// <param name="hostContext">Context containing the current state of the host.</param>
	/// <param name="configBuilder">Builder providing the current configuration state, and enabling further changes.</param>
	/// <param name="args">String arguments passed to the program</param>
	public abstract void Configure(HostBuilderContext hostContext, IConfigurationBuilder configBuilder, string[] args);
}
