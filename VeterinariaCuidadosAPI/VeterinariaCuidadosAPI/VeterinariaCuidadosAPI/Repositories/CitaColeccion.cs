using MongoDB.Bson;
using MongoDB.Driver;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public class CitaColeccion : ICitaColeccion
    {
        internal MongoBBRepository _repository = new MongoBBRepository();
        private IMongoCollection<Cita> Collection;

        public CitaColeccion()
        {
            Collection = _repository.db.GetCollection<Cita>("Cita");
        }

        public async Task DeleteCita(string id)
        {
            var filtro = Builders<Cita>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filtro);
        }

        public async Task<List<Cita>> GetAllCitas()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Cita> GetCitasById(string id)
        {
            return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertCita(Cita cita)
        {
            await Collection.InsertOneAsync(cita);
        }

        public async Task UpdateCita(Cita cita)
        {
            if (cita == null || cita.Id == "")
            {
                throw new ArgumentException("La cita o el Id no pueden ser nulos o vacíos.");
            }

            var filter = Builders<Cita>.Filter.Eq(s => s.Id, cita.Id);

            await Collection.ReplaceOneAsync(filter, cita);
        }
    }
}