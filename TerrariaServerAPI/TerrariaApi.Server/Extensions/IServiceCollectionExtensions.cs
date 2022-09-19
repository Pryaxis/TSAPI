using Microsoft.Extensions.DependencyInjection;
using TerrariaApi.Server;

static class IServiceCollectionExtensions
{
	public static IServiceCollection AddPluginService(this IServiceCollection services, Type pluginServiceType) =>
		services.AddSingleton(pluginServiceType)
				.AddSingleton(typeof(PluginService), implFactory => implFactory.GetRequiredService(pluginServiceType));
}
