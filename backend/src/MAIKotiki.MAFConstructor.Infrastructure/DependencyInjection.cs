using MAIKotiki.MAFConstructor.Infrastructure.Repository;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MAIKotiki.MAFConstructor.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection RegisterInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<SystemChannelConfigurationRepository>();
        
        return services;
    }
}