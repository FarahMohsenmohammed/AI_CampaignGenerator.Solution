using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using AI_CampaignGenerator.Domain.Entities.ProductModule;
using AI_CampaignGenerator.Domain.Entities.UserModule;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.DbContexts
{
  public class AICampaignGeneratorDbContext:DbContext
    {
        public AICampaignGeneratorDbContext(DbContextOptions<AICampaignGeneratorDbContext>options):base(options) 
        {
            
        }
        //for applying configurations
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //the assembly that has dbcontexts is different from the one that has configurations so we cannot use get excuting assemply
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(ProductConfiguration).Assembly);
            //it is not diff so we can use it
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


        }
        #region dbsets
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<Campaign> Campaigns { get; set; }


        public DbSet<AIGeneratedContent> AIGeneratedContent { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<AIGeneratedContentImages> AIGeneratedImages { get; set; }

        #endregion

    }
}

