using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace TerrariaApi.Server;

/// <summary>
/// Loads plugin services from the DI container and invokes their <code>Start()</code> method.
/// </summary>
internal sealed class ServiceLoader
{
	private IServiceProvider _services;
	private ILogger<ServiceLoader> _logger;

	internal ServiceLoader(IServiceProvider services, ILogger<ServiceLoader> logger)
	{
		this._services = services;
		this._logger = logger;
	}

	internal void LoadServices()
	{
		IOrderedEnumerable<PluginService> pluginServices =
			from pluginService in _services.GetServices<PluginService>()
			orderby pluginService.Priority descending
			select pluginService;

		foreach (PluginService service in pluginServices)
		{
			try
			{
				service.Start();
				_logger.LogInformation("Plugin service {serviceName} started.", service.GetType().Name);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to start plugin service {serviceName}", service.GetType().Name);
			}
		}
	}
}
