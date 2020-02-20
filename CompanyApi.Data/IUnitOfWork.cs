using System;
using System.Threading.Tasks;
using CompanyApi.Data.Repository;

namespace CompanyApi.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository Repository { get; }

        Task<int> SaveChangesAsync();
    }
}
