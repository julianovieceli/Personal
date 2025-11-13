using Microsoft.Extensions.DependencyInjection;
using Personal.Common.Domain.Interfaces.Repository;

namespace Personal.Common.Infra.Mysql.Repository
{
    public static class IoC

    {
        public static IServiceCollection AddMySqlDbContext(this IServiceCollection services)
        {
            return services.AddScoped<IDbContext, MySqlDbcontext>();
        }
    }
}
