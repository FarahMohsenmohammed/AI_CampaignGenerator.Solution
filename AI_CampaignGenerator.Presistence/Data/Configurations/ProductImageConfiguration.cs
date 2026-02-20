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
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImages>
    {
        public void Configure(EntityTypeBuilder<ProductImages> builder)
        {
            builder.HasKey(img => img.Id);

            builder.Property(p => p.ImageURL)
              .HasColumnType("varchar(500)")
              .HasMaxLength(500)
              .IsRequired();

           
        }
    }
}
