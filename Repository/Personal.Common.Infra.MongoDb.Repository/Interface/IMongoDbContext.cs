using MongoDB.Driver;

namespace Personal.Common.Infra.MongoDb.Repository.Interfaces
{
    public interface IMongoDbcontext
    {
        IMongoDatabase DataBase { get; }
    }
}
