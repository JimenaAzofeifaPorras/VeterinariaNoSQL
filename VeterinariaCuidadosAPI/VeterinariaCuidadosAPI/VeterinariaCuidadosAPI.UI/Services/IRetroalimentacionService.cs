using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public interface IRetroalimentacionService
    {
            Task<IEnumerable<Retroalimentacion>> GetAllRetroalimentacion();
            Task<Retroalimentacion> GetRetroalimentacionDetails(string id);
            Task SaveRetroalimentacion(Retroalimentacion retroalimentacion);
            Task DeleteRetroalimentacion(string id);
        }
    }
}
