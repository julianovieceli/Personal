namespace Personal.Common.Domain.Interfaces.Repository
{
    public interface ILogRepository
    {
        Task Register(Log room);
    }
}
