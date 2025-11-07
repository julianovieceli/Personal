using Microsoft.Extensions.DependencyInjection;
using Personal.Common.Services;

namespace Personal.Common
{
    public static class IoC
    {
        public static IServiceCollection AddLogService(this IServiceCollection services)
        {
            return services.AddScoped<ILogService, LogService>();
        }

    }

}
