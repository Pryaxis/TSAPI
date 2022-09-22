using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace TerrariaApi.Configurator;

/// <summary>
/// Describes a class that will provide additional configuration for logging
/// </summary>
public abstract class LoggingConfigurator : BaseConfigurator
{
	/// <summary>
	/// Configure the given logging builder.
	/// This can be used to add new log providers, adjusting log levels, etc.
	/// <para/>
	/// For more information read the .NET Logging documentation:
	/// <seealso cref="https://docs.microsoft.com/en-us/dotnet/core/extensions/logging"/>
	/// </summary>
	/// <param name="hostContext">Context containing the current state of the host.</param>
	/// <param name="logBuilder">Builder providing the existing logging configuration state, and enabling further changes.</param>
	/// <param name="args">String arguments passed to the program</param>
	public abstract void Configure(HostBuilderContext hostContext, ILoggingBuilder logBuilder, string[] args);
}
