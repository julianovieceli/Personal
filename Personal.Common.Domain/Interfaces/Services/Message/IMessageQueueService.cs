namespace Personal.Common.Domain.Interfaces.Services.Message
{
    public interface IMessageQueueService
    {
        Task SendMessageAsync<T>(T msg);
    }
}
