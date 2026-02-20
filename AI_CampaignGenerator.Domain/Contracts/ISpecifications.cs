using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Domain.Contracts
{
    public interface ISpecifications<TEntity,TKey> where TEntity:BaseEntity<TKey>
    {
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; }
        public Expression<Func<TEntity, bool>> Criteria { get; }
      
        public int Skip { get; }
        public int Take { get; }
        public bool IsPaginated { get; }

    }
}
