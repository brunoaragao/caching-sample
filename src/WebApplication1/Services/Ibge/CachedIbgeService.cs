using Microsoft.Extensions.Caching.Memory;

using rmdev.ibge.localidades;

namespace WebApplication1.Services.Ibge;

public class CachedIbgeService(IIBGELocalidades sdk, IMemoryCache cache) : IIbgeService
{
    public async Task<ICollection<Municipio>> BuscarMunicipioPorUFAsync(long idUf)
    {
        var key = $"municipios-{idUf}";

        var municipios = await cache.GetOrCreateAsync(key, async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromMinutes(5));
            return await sdk.BuscarMunicipioPorUFAsync(idUf);
        });

        return [.. municipios!.OrderBy(x => x.Nome)];
    }

    public async Task<ICollection<UF>> BuscarUFsAsync()
    {
        var key = "ufs";

        var ufs = await cache.GetOrCreateAsync(key, async entry =>
        {
            entry.SetAbsoluteExpiration(TimeSpan.FromHours(1));
            return await sdk.BuscarUFsAsync();
        });

        return [.. ufs!.OrderBy(x => x.Nome)];
    }
}