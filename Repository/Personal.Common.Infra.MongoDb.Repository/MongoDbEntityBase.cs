using MongoDB.Bson;

namespace Personal.Common.Infra.MongoDb.Repository.Repository
{
    public abstract class MongoDbEntityBase
    {
        public ObjectId Id { get; set; }
    }
}
