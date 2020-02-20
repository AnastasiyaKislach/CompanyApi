using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using CompanyApi.Data.Entities;

namespace CompanyApi.Data.Repository
{
    public class Repository : IRepository
    {
        private readonly DbContext _dbContext;

        public Repository(DbContext context)
        {
            _dbContext = context;
        }

        public async Task Create<TEntity>(TEntity entity) where TEntity : Entity
        {
           await _dbContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete<TEntity>(int id) where TEntity : Entity
        {
            var entity = await GetById<TEntity>(id);
            _dbContext.Set<TEntity>().Remove(entity);
        }

        public IQueryable<TEntity> GetAll<TEntity>() where TEntity : Entity
        {
            return _dbContext.Set<TEntity>().AsQueryable();
        }

        public async Task<TEntity> GetById<TEntity>(int id) where TEntity : Entity
        {
            return await _dbContext.Set<TEntity>().FindAsync(id);
        }

        public Task Update<TEntity>(TEntity entity) where TEntity : Entity
        {
            _dbContext.Set<TEntity>().Update(entity);

            return Task.CompletedTask;
        }
    }
}
