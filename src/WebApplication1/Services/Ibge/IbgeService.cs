using rmdev.ibge.localidades;

namespace WebApplication1.Services.Ibge;

public class IbgeService(IIBGELocalidades sdk) : IIbgeService
{
    public async Task<ICollection<Municipio>> BuscarMunicipioPorUFAsync(long idUf)
    {
        var municipios = await sdk.BuscarMunicipioPorUFAsync(idUf);
        return [.. municipios.OrderBy(x => x.Nome)];
    }

    public async Task<ICollection<UF>> BuscarUFsAsync()
    {
        var ufs = await sdk.BuscarUFsAsync();
        return [.. ufs!.OrderBy(x => x.Nome)];
    }
}