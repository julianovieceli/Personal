using MongoDB.Bson;
using System.Linq.Expressions;

namespace Personal.Common.MongoDb.Repository.Interface
{
    public interface IMongoDbRepositoryBase<TEntity> where TEntity : MongoDbEntityBase
    {
        Task<bool> InsertAsync(TEntity mongoDbEntityBase);

        Task<TEntity> GetAsync(ObjectId id);

        Task<IList<TEntity>> GetAllAsync();


        Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> filter);

    }
}
