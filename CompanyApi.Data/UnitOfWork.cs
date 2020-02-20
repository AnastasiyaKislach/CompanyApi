using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using CompanyApi.Data.Repository;

namespace CompanyApi.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;

        public UnitOfWork(IRepository repository, DbContext context)
        {
            _context = context;
            Repository = repository;
        }

        public IRepository Repository { get; private set; }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
