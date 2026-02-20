using AI_CampaignGenerator.Domain.Entities.UserModule;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AI_CampaignGenerator.Presistence.Data.Configurations
{
        public class UserConfiguration : IEntityTypeConfiguration<User>
        {
            public void Configure(EntityTypeBuilder<User> builder)
            {

                builder.Property(u => u.FirstName)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();
                builder.Property(u => u.LastName)
                    .HasColumnType("varchar(50)")
                    .HasMaxLength(50)
                    .IsRequired();
                builder.Property(x => x.CreatedAt)
                   .HasColumnName("JoinDate")
                   .HasDefaultValueSql("GETUTCDATE()")
                   .ValueGeneratedOnAdd()
                   .IsRequired();//wehen insrting user without assigning date it will put current date,time
                builder.Property(x => x.Email)
                  .HasColumnType("varchar(100)")
                  .HasMaxLength(100)
                  .IsRequired();
            builder.HasIndex(x => x.Email)
                .IsUnique();//to not store the same email twice



                builder.ToTable(tb =>
                {
                    tb.HasCheckConstraint("ValidEmailCheck", "Email Like '_%@_%._%'");

                });
                //user with products 
                builder.HasMany(u => u.Products)
                    .WithOne(p => p.User)
                    .HasForeignKey(p => p.UserId)
                    .OnDelete(DeleteBehavior.Restrict);

                //campaigns
                builder.HasMany(u => u.Campaigns)
                    .WithOne(c => c.User)
                    .HasForeignKey(c => c.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            //user authentication is handeled externally not included in the current implementation


            }
        }
}
