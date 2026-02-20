using AI_CampaignGenerator.Domain;
using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Presistence.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.Repositories
{
    public class GenericRepository<TEntity, TKey> : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>

    {
        private readonly AICampaignGeneratorDbContext _dbcontext;

        public GenericRepository(AICampaignGeneratorDbContext dbcontext )
        {
            _dbcontext = dbcontext;
        }
        public async Task AddAsync(TEntity entity) => await _dbcontext.Set<TEntity>().AddAsync(entity);


        public async Task<IEnumerable<TEntity>> GetAllAsync()=>await _dbcontext.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(TKey id) => await _dbcontext.Set<TEntity>().FindAsync(id);


        public void Remove(TEntity entity) => _dbcontext.Set<TEntity>().Remove(entity);


        public void Update(TEntity entity) => _dbcontext.Set<TEntity>().Update(entity);
        //remove and update donot have another version async
        private IQueryable<TEntity>ApplySpecification(ISpecifications<TEntity,TKey> spec)
        {
            return SpecificationEvaluator.CreateQuery(_dbcontext.Set<TEntity>().AsQueryable(), spec);
        }
    }
}
