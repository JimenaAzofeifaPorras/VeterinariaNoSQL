using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public interface IMascotaService
    {
        Task<IEnumerable<Mascota>> GetAllMascota();
        Task<Mascota> GetMascotaDetails(string id);
        Task SaveMascota(Mascota mascota);
        Task DeleteMascota(string id);
    }
}
