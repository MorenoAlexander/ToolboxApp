using Microsoft.Extensions.DependencyInjection;

namespace ToolboxApp.Data.Configuration;

public static class ConfigureDataServices
{
    public static IServiceCollection AddDataServices(this IServiceCollection services)
    {

        services.AddScoped<IConnectionFactory, SqlConnectionFactory>();

        return services;
    }
}