using MongoDB.Driver;

namespace VeterinariaCuidadosAPI.Repositories
{
    public class MongoBBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public MongoBBRepository()
        {
            client = new MongoClient("mongodb://localhost:27017");

            db = client.GetDatabase("VeterinariaCuidados");
        }
    }
}
