using MongoDB.Driver;
using Personal.Common.MongoDb.Repository.Interfaces;

namespace Personal.Common.MongoDb.Repository
{
    public class MongoDbContext: IMongoDbcontext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            _database = client.GetDatabase(databaseName);
        }

        public IMongoDatabase DataBase
        {
            get { return _database; }
        }
    }
}
