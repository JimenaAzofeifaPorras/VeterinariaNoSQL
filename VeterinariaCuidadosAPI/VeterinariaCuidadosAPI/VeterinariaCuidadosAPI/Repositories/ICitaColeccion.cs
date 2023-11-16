using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public interface ICitaColeccion
    {
        Task InsertCita(Cita cita);

        Task UpdateCita(Cita cita);

        Task DeleteCita(String id);

        Task<List<Cita>> GetAllCitas();

        Task<Cita> GetCitasById(String id);
    }
}

