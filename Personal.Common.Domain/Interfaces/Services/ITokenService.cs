
namespace Personal.Common.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        Result GenerateToken(string userName);
    }
}
