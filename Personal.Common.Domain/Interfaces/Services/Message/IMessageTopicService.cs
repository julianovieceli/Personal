namespace Personal.Common.Domain.Interfaces.Services.Message
{
    public interface IMessageTopicService
    {
        Task PublishMessageAsync<T>(string topic, T msg);
    }
}
