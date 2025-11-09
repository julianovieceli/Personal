using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Personal.Common.Domain.Interfaces.Services;
using Personal.Common.Handlers.Authentication;
using Personal.Common.Services;
using Personal.Common.Settings;
using System.Text;
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

        public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            JwtSettings jwtSettings = new JwtSettings();
            configuration.GetSection(nameof(JwtSettings)).Bind(jwtSettings);



            string jwtKey = jwtSettings.Key;

            bool validateIssuer = !string.IsNullOrWhiteSpace(jwtSettings.Issuer);
            bool validateAudience = !string.IsNullOrWhiteSpace(jwtSettings.Audience); ;



            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = validateIssuer,
                        ValidateAudience = validateAudience,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = validateIssuer,
                        ValidIssuer = validateIssuer ? jwtSettings.Issuer : null,
                        ValidAudience = validateAudience ? jwtSettings.Audience : null,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            // Log when a token is received
                            Console.WriteLine($"Token received: {context.Token}");
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            // Log authentication failures
                            Console.WriteLine($"Authentication failed: {context.Exception.Message}");
                            return Task.CompletedTask;
                        },
                        OnTokenValidated = context =>
                        {
                            // Log successful token validation
                            Console.WriteLine($"Token validated for user: {context.Principal?.Identity?.Name}");
                            return Task.CompletedTask;
                        }
                    };
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
