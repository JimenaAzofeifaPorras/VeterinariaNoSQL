using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public interface IRecetaColeccion
    {
        Task InsertReceta(Receta receta);

        Task UpdateReceta(Receta receta);

        Task DeleteReceta(String id);

        Task<List<Receta>> GetAllRecetas();

        Task<Receta> GetRecetaById(String id);
    }
}
