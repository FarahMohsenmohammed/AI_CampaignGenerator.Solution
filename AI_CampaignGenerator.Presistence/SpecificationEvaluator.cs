using AI_CampaignGenerator.Domain;
using AI_CampaignGenerator.Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence
{
  internal static class SpecificationEvaluator
    {
        public static IQueryable<TEntity> CreateQuery<TEntity, TKey>(IQueryable<TEntity> EntryPoint,
            ISpecifications<TEntity, TKey> specifications) where TEntity : BaseEntity<TKey>
        {
            var Query = EntryPoint;
            if (specifications is not null)
            {
                if (specifications.Criteria is not null)
                {
                    Query = Query.Where(specifications.Criteria);
                }
                if (specifications.IncludeExpressions is not null && specifications.IncludeExpressions.Any())
                {
                    //foreach(var IncludeExp in specifications.IncludeExpressions)
                    //{
                    //    Query = Query.Include(IncludeExp);

                    //}

                    Query = specifications.IncludeExpressions.Aggregate(Query, (CurrentQuery, IncludeExp) => CurrentQuery.Include(IncludeExp));
                }
               
                if (specifications.IsPaginated)
                {
                    Query = Query.Skip(specifications.Skip).Take(specifications.Take);

                }
            }
            return Query;
        }

    }
    
}
