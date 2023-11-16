using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.UI.Services
{
    public interface IRecetaService
    {
        Task<IEnumerable<Receta>> GetAllReceta();
        Task<Receta> GetRecetaDetails(string id);
        Task SaveReceta(Receta receta);
        Task DeleteReceta(string id);
    }
}
