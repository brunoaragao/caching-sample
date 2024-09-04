using rmdev.ibge.localidades;

namespace WebApplication1.Services.Ibge;

public interface IIbgeService
{
    Task<ICollection<UF>> BuscarUFsAsync();
    Task<ICollection<Municipio>> BuscarMunicipioPorUFAsync(long idUf);
}