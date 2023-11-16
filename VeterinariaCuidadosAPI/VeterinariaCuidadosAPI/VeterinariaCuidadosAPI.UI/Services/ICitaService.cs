using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
        public interface ICitaService
        {
            Task<IEnumerable<Cita>> GetAllCitas();
            Task<Cita> GetCitasDetails(string id);
            Task SaveCitas(Cita cita);
            Task DeleteCitas(string id);
        }
    }
}
