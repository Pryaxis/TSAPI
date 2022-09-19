using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace TerrariaApi.Configurator;

/// <summary>
/// Describes a class that will provide additional service configuration
/// </summary>
public abstract class ServiceConfigurator : BaseConfigurator
{
	/// <summary>
	/// Configure the given service collection.
	/// Values added to the service collection can be used with dependency injection.
	/// <para/>
	/// For more information read the .NET DI documentation
	/// <seealso cref="https://docs.microsoft.com/en-us/dotnet/core/extensions/dependency-injection"/>
	/// </summary>
	/// <param name="hostContext">Context containing the current state of the host.</param>
	/// <param name="services">Collection of services currently configured on the host.</param>
	public abstract void Configure(HostBuilderContext hostContext, IServiceCollection services);
}
