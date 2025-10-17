using Microsoft.Extensions.DependencyInjection;

namespace PluginHost;

public interface IServiceRegistration
{
    void RegisterServices(IServiceCollection services);
}