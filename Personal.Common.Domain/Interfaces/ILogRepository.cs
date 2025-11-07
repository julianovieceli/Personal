namespace Personal.Common.Domain.Interfaces
{
    public interface ILogRepository
    {
        Task Register(Log room);
    }
}
