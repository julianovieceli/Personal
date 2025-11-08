using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Personal.Common.Domain.Interfaces.Services;
using Personal.Common.Handlers.Authentication;
using Personal.Common.Services;
using Personal.Common.Settings;
using static Personal.Common.Handlers.Authentication.BasicAuthenticationHandler;

namespace Personal.Common
{
    public static class IoC
    {
        public static IServiceCollection AddLogService(this IServiceCollection services)
        {
            return services.AddScoped<ILogService, LogService>();
        }


        public static IServiceCollection AddBasicAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<UserAuthenticationSettings>(configuration.GetSection(nameof(UserAuthenticationSettings)));

            services.AddAuthentication(BasicAuthenticationOptions.DefaultScheme)
            .AddScheme<BasicAuthenticationOptions, BasicAuthenticationHandler>(BasicAuthenticationOptions.DefaultScheme, options => {


            });

            services.AddAuthorizationCore();

            


            return services;
        }


        public static IServiceCollection AddJwtTokenConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection(nameof(JwtSettings)));

            services.AddScoped<ITokenService, JwtTokenService>();

            return services;
        }

    }

}
