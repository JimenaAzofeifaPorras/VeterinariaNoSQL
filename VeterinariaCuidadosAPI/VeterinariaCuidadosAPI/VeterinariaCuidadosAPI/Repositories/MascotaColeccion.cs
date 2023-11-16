using MongoDB.Bson;
using MongoDB.Driver;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public class MascotaColeccion : IMascotaColeccion
    {

        internal MongoBBRepository _repository = new MongoBBRepository();
        private IMongoCollection<Mascota> Collection;

        public MascotaColeccion()
        {
            Collection = _repository.db.GetCollection<Mascota>("Mascota");
        }
        public async Task DeleteMascota(string id)
        {
            var filtro = Builders<Mascota>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filtro);
        }

        public async Task<List<Mascota>> GetAllMascotas()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Mascota> GetMascotaById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertMascota(Mascota mascota)
        {
            await Collection.InsertOneAsync(mascota);
        }

        public async Task UpdateMascota(Mascota mascota)
        {
            if (mascota == null)
            {
                throw new ArgumentException("La mascota o el Id no pueden ser nulos o vacíos.");
            }

            var filter = Builders<Mascota>.Filter.Eq(s => s.Id, mascota.Id);

            await Collection.ReplaceOneAsync(filter, mascota);
        }

        Task<List<Mascota>> IMascotaColeccion.GetAllMascotas()
        {
            throw new NotImplementedException();
        }

        Task<Mascota> IMascotaColeccion.GetMascotaById(string id)
        {
            throw new NotImplementedException();
        }
    }
}

