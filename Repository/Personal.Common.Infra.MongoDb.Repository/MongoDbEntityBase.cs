using MongoDB.Bson;

namespace Personal.Common.Infra.MongoDb.Repository
{
    public abstract class MongoDbEntityBase
    {
        
        public virtual ObjectId Id { get; set; }
    }
}
