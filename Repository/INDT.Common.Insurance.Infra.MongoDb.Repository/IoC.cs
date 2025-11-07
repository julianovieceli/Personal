using Microsoft.Extensions.DependencyInjection;
using Personal.Common.MongoDb.Repository.Interfaces;



namespace Personal.Common.MongoDb.Repository
{
    public static class Ioc
    {
        public static IServiceCollection AddMongoDbContext(this IServiceCollection services, string connString, string database)
        {

            return services.AddSingleton<IMongoDbcontext>(s =>
            {
                return new MongoDbContext(connString, database);
                
            });
        
        }
    }
}
