using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Linq.Expressions;

namespace AuditInfrastructure.Service
{
    public class MainService<T,N,M>: IMainService<T,N,M>
        where T : class 
        where N : class
        where M : class 
    {
        private readonly IRepository<T> _Repository;
        private readonly IMapper _mapper;
        public MainService(IRepository<T> Repository, IMapper mapper)
        {
            _Repository = Repository;
            _mapper = mapper;
        }

        public async Task<N> CreateNew(N DTO)
        {
            var Entity = _mapper.Map<T>(DTO);
            await _Repository.Add(Entity);
            DTO = _mapper.Map<N>(Entity);
            return DTO;
        }

        public async Task<bool> DeleteExist(int id)
        {
            var existEntity = await _Repository.GetIntParam(id);

            if (existEntity != null)
            {
                await _Repository.Delete(existEntity);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<M> GetById(int id)
        {
            var existEntity = await _Repository.GetIntParam(id);
            var returnUpdatedValue = _mapper.Map<M>(existEntity);
            return returnUpdatedValue;
        }

        public async Task<IEnumerable<M>> GetExistAsync()
        {
            var entity = await _Repository.GetValues();
            var Dto = _mapper.Map<IEnumerable<M>>(entity);
            return Dto;
        }

        public async Task<IEnumerable<M>> GetSortedValuesAsync(Expression<Func<T, object>> sortExpression)
        {
            var queryableValues = _Repository.GetQueryableValues();
            var sortedValues = queryableValues.OrderBy(sortExpression);
            var entities = await sortedValues.ToListAsync();
            var dto = _mapper.Map<IEnumerable<M>>(entities);
            return dto; 
        }

        public async Task<N> UpdateExist(int id, N DTO)
        {
            var existEntity = await _Repository.GetIntParam(id);
            var mappedEntity = _mapper.Map(DTO, existEntity);
            await _Repository.Update(mappedEntity);
            var returnUpdatedValue = _mapper.Map<N>(mappedEntity);
            return returnUpdatedValue;
        }
    }
}
