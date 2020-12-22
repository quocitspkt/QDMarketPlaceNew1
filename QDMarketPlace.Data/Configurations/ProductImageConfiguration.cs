using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ProductImageConfiguration : IEntityTypeConfiguration<ProductImage>
    {
        public void Configure(EntityTypeBuilder<ProductImage> builder)
        {
            builder.ToTable("ProductImages");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.ImagePath).HasMaxLength(200).IsRequired(true);
            builder.Property(x => x.Caption).HasMaxLength(200);

            builder.HasOne(x => x.Product).WithMany(x => x.ProductImages).HasForeignKey(x => x.ProductId);
        }
    }
}
