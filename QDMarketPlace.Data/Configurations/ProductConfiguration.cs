using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x=>x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(128).IsUnicode();
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.OriginalPrice).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Image).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ThumbImage).HasMaxLength(255).IsUnicode(false);
            builder.Property(x => x.ViewCount).HasDefaultValue(0);
            builder.Property(x => x.Video).HasMaxLength(250);
            builder.Property(x => x.SeoPageTitle).HasMaxLength(128).IsUnicode(false);
            builder.Property(x => x.SeoAlias).HasMaxLength(128).IsUnicode(false);
            builder.Property(x => x.SeoDescription).HasMaxLength(158).IsUnicode(false);
            builder.Property(x => x.SeoKeyWord).HasMaxLength(158).IsUnicode(false);
            builder.HasOne(x => x.ProductCategory).WithMany(x => x.Products).HasForeignKey(x => x.CategoryId);

        }
    }
}
