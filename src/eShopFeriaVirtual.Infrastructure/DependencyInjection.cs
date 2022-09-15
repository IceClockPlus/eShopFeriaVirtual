using eShopFeriaVirtual.Infrastructure.Database;
using Microsoft.Extensions.DependencyInjection;

namespace eShopFeriaVirtual.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        services.AddSingleton<IApplicationDbContext, ApplicationDbContext>();
        return services;
    }
}
