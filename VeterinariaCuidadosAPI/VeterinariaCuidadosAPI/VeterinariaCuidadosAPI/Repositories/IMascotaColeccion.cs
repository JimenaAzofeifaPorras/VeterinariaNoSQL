using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public interface IMascotaColeccion
    {
        Task InsertMascota(Mascota mascota);

        Task UpdateMascota(Mascota mascota);

        Task DeleteMascota(String id);

        Task<List<Mascota>> GetAllMascotas();

        Task<Mascota> GetMascotaById(String id);
    }
}
