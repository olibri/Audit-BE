using AuditInfrastructure.Data;
using AuditInfrastructure.Service;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuditInfrastructure
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AuditDbContext _dbContext;
        public Repository(AuditDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<T> Add(T value)
        {
            await _dbContext.Set<T>().AddAsync(value);
            await _dbContext.SaveChangesAsync();
            return value;
        }

        public async Task Delete(T valueId)
        {
            _dbContext.Set<T>().Remove(valueId);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T> GetIntParam(int valueId)
        {
            return await _dbContext.Set<T>().FindAsync(valueId);
        }

        public async Task<IEnumerable<T>> GetValues()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task Update(T value)
        {
            _dbContext.Entry(value).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
        public IQueryable<T> GetQueryableValues()
        {
            return _dbContext.Set<T>();
        }

        public async Task<T> GetStringParam(string value)
        {
            return await _dbContext.Set<T>().FindAsync(value);
        }
    }
}
