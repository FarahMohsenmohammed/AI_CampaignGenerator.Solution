using AI_CampaignGenerator.Domain;
using AI_CampaignGenerator.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Services.Specifications
{
  public abstract class BaseSpecifications<TEntity, TKey> : ISpecifications<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
       
        #region Criteria
        public Expression<Func<TEntity, bool>> Criteria { get; }
        
        protected BaseSpecifications(Expression<Func<TEntity, bool>> criteriaExpression)
        {
            Criteria=criteriaExpression;
        }
        #endregion
        #region include
        public ICollection<Expression<Func<TEntity, object>>> IncludeExpressions { get; } = [];


        protected void AddInclude(Expression<Func<TEntity, object>> includeExp)
        {
            IncludeExpressions.Add(includeExp);
        }

        #endregion
      

        #region Pagination
        public int Take { get; private set; }
        public int Skip { get; private set; }
        public bool IsPaginated { get; private set; }
        protected void ApplyPagination(int pageSize, int pageIndex)
        {
            IsPaginated = true;
            Take = pageSize;
            Skip = (pageIndex - 1) * pageSize;
        }
        #endregion


       
    }
}
