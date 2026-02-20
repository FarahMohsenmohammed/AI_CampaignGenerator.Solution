using AI_CampaignGenerator.Domain.Entities.Ai_GeneratedContentModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.Configurations
{
    public class AIGeneratedImageConfiguration : IEntityTypeConfiguration<AIGeneratedContentImages>
    {

        public void Configure(EntityTypeBuilder<AIGeneratedContentImages> builder)
        {

            //builder.HasKey(img => img.Id);

            builder.Property(img => img.GeneratedImageURL)
                   .HasColumnType("nvarchar(MAX)")
                   .IsRequired();



            //// Ai_Generated_Content → Ai_Generated_Content_Images (One-to-Many)
            //builder.HasOne(img => img.Content)
            //           .WithMany(c => c.Images)
            //           .HasForeignKey(img => img.ContentId)
            //           .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
