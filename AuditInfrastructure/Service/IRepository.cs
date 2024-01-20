using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace AuditInfrastructure.Service
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetValues();
        Task<T> Add(T value);
        Task Update(T value);
        Task Delete(T valueId);
        Task<T> GetIntParam(int value);
        Task<T> GetStringParam(string value);
        IQueryable<T> GetQueryableValues();        
    }
}
