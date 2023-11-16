using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public interface IRetroalimentacionColeccion
    {

        Task InsertRetroalimentacion(Retroalimentacion retroalimentacion);

        Task UpdateRetroalimentacion(Retroalimentacion retroalimentacion);

        Task DeleteRetroalimentacion(String id);

        Task<List<Retroalimentacion>> GetAllRetroalimentacion();

        Task<Retroalimentacion> GetRetroalimentacionById(String id);
    }
}