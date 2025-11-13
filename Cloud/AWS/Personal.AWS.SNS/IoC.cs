using Amazon.SimpleNotificationService;
using Microsoft.Extensions.DependencyInjection;
using Personal.Common.Domain.Interfaces.Services.Message;

namespace Personal.AWS.SNS
{
    public static class IoC
    {
        public static IServiceCollection AddAWSSnsService(this IServiceCollection services)
        {
            services.AddAWSService<IAmazonSimpleNotificationService>();
            return services.AddScoped<IMessageTopicService, SnsService>();
        }
    }
}
