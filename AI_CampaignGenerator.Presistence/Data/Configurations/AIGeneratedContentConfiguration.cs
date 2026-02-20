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
    public class AIGeneratedContentConfiguration : IEntityTypeConfiguration<AIGeneratedContent>
    {

        public void Configure(EntityTypeBuilder<AIGeneratedContent> builder)
        {

            //builder.HasKey(ai => ai.Id);

            builder.Property(ai => ai.IdealHashtags)
                   .HasColumnType("nvarchar(MAX)")
                   .IsRequired(false);

            builder.Property(ai => ai.IdealCaption)
                   .HasColumnType("nvarchar(MAX)")
                   .IsRequired(false);

            builder.Property(ai => ai.Season)
                   .HasColumnType("varchar(50)")
                   .IsRequired(false);



            builder.Property(ai => ai.AdTone)
                   .HasColumnType("varchar(50)")
                   .IsRequired(false);


            // CreatedAt من BaseEntity
            builder.Property(ai => ai.CreatedAt)
                   .HasColumnName("GeneratedAt")
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd();

            builder.Property(a => a.Language)
                .HasConversion<string>()
                .IsRequired();
            builder.Property(a => a.ImagePrompt)
                .HasColumnType("nvarchar(MAX)")
                .IsRequired();
            builder.Property(a => a.UploadedImageURL)
                .HasMaxLength(1000)
                .IsRequired(false);



            // Ai_Generated_Content → Campaigns (Many-to-One)
            builder.HasOne(ai => ai.Campaign)
                   .WithMany(c => c.AIContents)
                   .HasForeignKey(ai => ai.CampaignId)
                   .OnDelete(DeleteBehavior.Cascade);


            // Ai_Generated_Content → Images (One-to-Many)
            builder.HasMany(ai => ai.Images)
                   .WithOne(img => img.Content)
                   .HasForeignKey(img => img.ContentId)
                   .OnDelete(DeleteBehavior.Cascade);


        }
    }
}
