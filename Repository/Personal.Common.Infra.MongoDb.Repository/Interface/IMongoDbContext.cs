using MongoDB.Driver;

namespace Personal.Common.MongoDb.Repository.Interfaces
{
    public interface IMongoDbcontext
    {
        IMongoDatabase DataBase { get; }
    }
}
