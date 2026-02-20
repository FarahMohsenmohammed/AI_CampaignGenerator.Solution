using AI_CampaignGenerator.Domain.Entities.ProductModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ProductCategory)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(p => p.ProductSubCategry)
                .HasMaxLength(100);

            builder.Property(p => p.Material)
               .HasMaxLength(100);
            builder.Property(p => p.ProductName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.ProductDescription)
               .HasColumnType("nvarchar(MAX)")
               .IsRequired(false);
            builder.Property(p => p.GenderFocus)
              .HasColumnType("nvarchar(100)")
              .IsRequired();
            builder.Property(p => p.TargetAudiencePersona)
              .HasMaxLength(100);
             
            builder.Property(x => x.CreatedAt)
              .HasColumnName("CreatedAt")
              .HasDefaultValueSql("GETUTCDATE()")
              .ValueGeneratedOnAdd()
              .IsRequired();
            builder.Property(p => p.USP)
                .HasMaxLength(500);
                
            builder.HasMany(p => p.ProductImages)
                .WithOne(pi => pi.Product)
                .HasForeignKey(pi => pi.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(p => p.Campaigns)
                .WithOne(p => p.Product)
                .HasForeignKey(p => p.ProductId)
                .OnDelete(deleteBehavior: DeleteBehavior.Cascade);
            

        }
    }
}