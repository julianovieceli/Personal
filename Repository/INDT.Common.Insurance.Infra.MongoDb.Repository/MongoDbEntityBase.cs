using MongoDB.Bson;

namespace Personal.Common.MongoDb.Repository
{
    public abstract class MongoDbEntityBase
    {
        public ObjectId Id { get; set; }
    }
}
