using System.Data;

namespace Personal.Common.Domain.Interfaces.Repository
{
    public interface IDbContext
    {
        IDbConnection? Connect();

        void Dispose();
    }
}
