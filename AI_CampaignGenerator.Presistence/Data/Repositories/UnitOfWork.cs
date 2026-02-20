using AI_CampaignGenerator.Domain;
using AI_CampaignGenerator.Domain.Contracts;
using AI_CampaignGenerator.Presistence.Data.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AICampaignGeneratorDbContext _dbcontext;
        private readonly Dictionary<Type, object> _repositories = [];


        public UnitOfWork(AICampaignGeneratorDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        {
            var EntityType = typeof(TEntity);
            if (_repositories.TryGetValue(EntityType, out object? repository))
                return (IGenericRepository<TEntity, TKey>)repository;
            var newRepo = new GenericRepository<TEntity, TKey>(_dbcontext);
            _repositories[EntityType] = newRepo;
            return newRepo;
        }

       public async Task<int> SaveChangesAsync() => await _dbcontext.SaveChangesAsync();


    }
}
