using MongoDB.Bson;
using MongoDB.Driver;
using VeterinariaCuidadosAPI.Models;

namespace VeterinariaCuidadosAPI.Repositories
{
    public class ClienteColeccion : IClienteColeccion
    {
        internal MongoBBRepository _repository = new MongoBBRepository();
        private IMongoCollection<Cliente> Collection;

        public ClienteColeccion()
        {
            Collection = _repository.db.GetCollection<Cliente>("Cliente");
        }
        public async Task DeleteCliente(string id)
        {
            var filter = Builders<Cliente>.Filter.Eq(s => s.Id, id);
            await Collection.DeleteOneAsync(filter);
        }

        public async Task<List<Cliente>> GetAllClientes()
        {
            return await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
        }

        public async Task<Cliente> GetClienteById(string id)
        {
            return await Collection.FindAsync(
                new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstAsync();
        }

        public async Task InsertCliente(Cliente cliente)
        {
            await Collection.InsertOneAsync(cliente);
        }

        public async Task UpdateCliente(Cliente cliente)
        {
            if (cliente == null)
            {
                throw new ArgumentException("El cliente o el Id no pueden ser nulos o vacíos.");
            }

            var filter = Builders<Cliente>.Filter.Eq(s => s.Id, cliente.Id);

            await Collection.ReplaceOneAsync(filter, cliente);
        }

    }
}
