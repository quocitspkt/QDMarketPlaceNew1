using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class CertificateConfiguration : IEntityTypeConfiguration<Certificate>
    {
        public void Configure(EntityTypeBuilder<Certificate> builder)
        {
            builder.ToTable("Certificates");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Shop).WithMany(x => x.Certificates).HasForeignKey(x => x.ShopId);
            builder.Property(x => x.Name).HasMaxLength(250).IsUnicode().IsRequired();
            builder.Property(x => x.Image).HasMaxLength(250).IsUnicode(false);
        }
    }
}
