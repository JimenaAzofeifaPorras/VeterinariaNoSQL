using MongoDB.Bson;
using MongoDB.Driver;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public class RetroalimentacionColeccion : IRetroalimentacionColeccion
    {

        internal MongoBBRepository _repository = new MongoBBRepository();
        private IMongoCollection<Retroalimentacion> Collection;

        public RetroalimentacionColeccion()
        {
            Collection = _repository.db.GetCollection<Retroalimentacion>("Retroalimentacion");
        }
        public async Task DeleteRetroalimentacion(string id)
        {
            var filtro = Builders<Retroalimentacion>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filtro);
        }

        public async Task<List<Retroalimentacion>> GetAllRetroalimentacion()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Retroalimentacion> GetRetroalimentacionById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertRetroalimentacion(Retroalimentacion retroalimentacion)
        {
            await Collection.InsertOneAsync(retroalimentacion);
        }

        public async Task UpdateRetroalimentacion(Retroalimentacion retroalimentacion)
        {
            if (retroalimentacion == null)
            {
                throw new ArgumentException("La retroalimentacion o el Id no pueden ser nulos o vacíos.");
            }

            var filter = Builders<Retroalimentacion>.Filter.Eq(s => s.Id, retroalimentacion.Id);

            await Collection.ReplaceOneAsync(filter, retroalimentacion);
        }
    }
}



