using Microsoft.Extensions.Logging;
using MongoDB.Bson;
using MongoDB.Driver;
using Personal.Common.Infra.MongoDb.Repository.Interface;
using Personal.Common.Infra.MongoDb.Repository.Interfaces;
using System.Linq.Expressions;

namespace Personal.Common.Infra.MongoDb.Repository
{
    public class MongoDbRepositoryBase<TEntity> : IMongoDbRepositoryBase<TEntity> where TEntity : MongoDbEntityBase
    {
        protected readonly ILogger<TEntity> _logger;
        protected readonly IMongoCollection<TEntity> _collection;

        public MongoDbRepositoryBase(IMongoDbcontext dbcontext, string collectionName, ILogger<TEntity> logger)
        {
            _collection = dbcontext.DataBase.GetCollection<TEntity>(collectionName);
            _logger = logger;
        }
        public async Task<bool> InsertAsync(TEntity mongoDbEntityBase)
        {
            try
            {
                await _collection.InsertOneAsync(mongoDbEntityBase);
                return true;
            }
            catch(Exception e)
            {
                _logger.LogError($"Erro ao inserir o documento : {e.Message}");
                throw;
            }
        }

        public async Task<TEntity> GetAsync(ObjectId id)
        {
            try
            {
                return await _collection.Find(e => e.Id == id).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar o documento {id} :Exception : {e.Message}");
                throw;
            }

        }

        public async Task<IList<TEntity>> GetAllAsync()
        {
            try
            {
                return await _collection.Find(_ => true).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar todos os o documentos: Exception :{e.Message}");
                throw;
            }
        }


        public async Task<TEntity> FindOneAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return await _collection.Find(filter).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar o documento. Exception : {e.Message}");
                throw;
            }
        }

        public async Task<IList<TEntity>> FindAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return await _collection.Find(filter).ToListAsync();
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar os documentos. Exception : {e.Message}");
                throw;
            }
        }

        public async Task<long> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            try
            {
                return await _collection.CountDocumentsAsync(filter);
            }
            catch (Exception e)
            {
                _logger.LogError($"Erro ao buscar o documento. Exception : {e.Message}");
                throw;
            }
        }



    }
}
