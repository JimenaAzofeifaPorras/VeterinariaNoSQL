using MongoDB.Bson;
using MongoDB.Driver;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public class RecetaColeccion : IRecetaColeccion
    {
        internal MongoBBRepository _repository = new MongoBBRepository();
        private IMongoCollection<Receta> Collection;

        public RecetaColeccion()
        {
            Collection = _repository.db.GetCollection<Receta>("Receta");
        }
        public async Task DeleteReceta(string id)
        {
            var filtro = Builders<Receta>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filtro);
        }

        public async Task<List<Receta>> GetAllRecetas()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Receta> GetRecetaById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertReceta(Receta receta)
        {
            await Collection.InsertOneAsync(receta);
        }

        public async Task UpdateReceta(Receta receta)
        {
            if (receta == null)
            {
                throw new ArgumentException("La receta el Id no pueden ser nulos o vacíos.");
            }

            var filter = Builders<Receta>.Filter.Eq(s => s.Id, receta.Id);

            await Collection.ReplaceOneAsync(filter, receta);

        }

        Task<List<Receta>> IRecetaColeccion.GetAllRecetas()
        {
            throw new NotImplementedException();
        }

        Task<Receta> IRecetaColeccion.GetRecetaById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
