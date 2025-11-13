using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.Extensions.Logging;
using Personal.Common.Domain.Interfaces.Services.Message;
using Personal.Common.Services;
using System.Text.Json;

namespace Personal.AWS.SNS
{
    public class SnsService : BaseService, IMessageTopicService
    {
        private readonly IAmazonSimpleNotificationService _snsClient;
        public SnsService(ILogger<SnsService> logger, IAmazonSimpleNotificationService snsClient): base(logger)
        {
            _snsClient = snsClient; 

        }
        public async Task PublishMessageAsync<T>(string topic, T msg)
        {

            try
            {
                var messagePayload = JsonSerializer.Serialize(msg);

                var publishRequest = new PublishRequest
                {
                    TopicArn = topic,
                    Message = messagePayload
                };

                var response = await _snsClient.PublishAsync(publishRequest);
                _logger?.LogInformation($"SNS Message published successfully. MessageId: {response.MessageId}");
            }
            catch (Exception ex)
            {
                _logger?.LogError(ex, "Error publishing SNS message.");
                throw; // Re-throw or handle the exception appropriately
            }
        }
    }
}
