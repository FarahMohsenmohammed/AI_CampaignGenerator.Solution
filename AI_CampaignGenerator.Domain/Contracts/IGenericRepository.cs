using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity,TKey> spec);
        Task<TEntity?> GetByIdAsync(TKey id);
        Task AddAsync(TEntity entity);//task returns void cause unit work who saves chanes not repository ,not neeeded to be async 
        void Remove(TEntity entity);
        void Update(TEntity entity);
    }
}
