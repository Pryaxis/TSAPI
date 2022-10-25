using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;

namespace TerrariaApi.Configurator;

/// <summary>
/// Configures the log provider, adding text file logging. 
/// <br/>
/// Runs with a priority of 0. Load logging config before this by adding a ConfigConfigurator with a priority >0.
/// </summary>
public class FileLoggingConfigurator : LoggingConfigurator
{
	/// <inheritdoc/>
	public override void Configure(HostBuilderContext hostContext, ILoggingBuilder logBuilder, string[] args)
	{
		logBuilder.AddNLog(hostContext.Configuration);
	}
}
