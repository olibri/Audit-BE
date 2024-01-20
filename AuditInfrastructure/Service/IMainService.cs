using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuditInfrastructure.Service
{
    /// <summary>
    /// T - Entity
    /// N - DTO Post
    /// M - DTO Get
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="N"></typeparam>
    /// <typeparam name="M"></typeparam>
    public interface IMainService<T,N,M>
    {
        Task<N> CreateNew(N valueDTO);
        Task<bool> DeleteExist(int id);
        Task<IEnumerable<M>> GetExistAsync();
        Task<N> UpdateExist(int id, N valueDTO);
        Task<IEnumerable<M>> GetSortedValuesAsync(Expression<Func<T, object>> sortExpression);

        Task<M> GetById(int id); 
    }
}
