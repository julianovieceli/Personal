namespace Personal.Common.Domain.Interfaces.Services.Message
{
    public interface IMessageTopicService
    {
        Task PublishMessageAsync(string topic, string msg);
    }
}
