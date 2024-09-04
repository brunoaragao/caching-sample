using Microsoft.Extensions.DependencyInjection.Extensions;

using rmdev.ibge.localidades;

namespace WebApplication1.Services.Ibge;

public static class IbgeServiceExtensions
{
    public static void AddCachedIbgeService(this IServiceCollection services)
    {
        services.AddMemoryCache();
        services.TryAddScoped(_ => new IBGEClientFactory().Build());
        services.AddScoped<IIbgeService, CachedIbgeService>();
    }

    public static void AddIbgeService(this IServiceCollection services)
    {
        services.TryAddScoped(_ => new IBGEClientFactory().Build());
        services.AddScoped<IIbgeService, IbgeService>();
    }
}