using Microsoft.Extensions.DependencyInjection;

namespace ToolboxApp.Features;

public static class FeatureConfiguration
{
    
    public static IServiceCollection AddFeatures(this IServiceCollection services)
    {
        // Add MediatR
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(FeatureConfiguration).Assembly));
        return services;
    }
}
