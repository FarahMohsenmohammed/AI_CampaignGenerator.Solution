using AI_CampaignGenerator.Domain.Entities.CmpaignsModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.Configurations
{
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {

        public void Configure(EntityTypeBuilder<Campaign> builder)
        {

            builder.Property(c => c.Campaign_Name)
                   .HasMaxLength(100)
                   .IsRequired();




            builder.Property(c => c.Platform)
                   .HasColumnType("nvarchar(50)")
                   .IsRequired(false);



            builder.Property(c => c.CampaignGoal)
                   .HasColumnType("nvarchar(100)")
                   .IsRequired();


            builder.Property(c => c.CreatedAt)
                   .HasColumnName("GeneratedAt")
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();


            builder.Property(c => c.EndDate)
                   .IsRequired(false);

            builder.Ignore(c => c.Status);

            // Campaign → Ai_Generated_Content (One-to-Many)
            builder.HasMany(c => c.AIContents)
                   .WithOne(ai => ai.Campaign)
                   .HasForeignKey(ai => ai.CampaignId)
                   .OnDelete(DeleteBehavior.Cascade);
            //campains -prod
            builder.HasOne(x => x.Product)
                .WithMany(c => c.Campaigns)
                .HasForeignKey(c => c.ProductId)
                .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
