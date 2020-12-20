using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.Description).IsUnicode().HasMaxLength(500);
            builder.Property(x => x.Name).IsRequired().IsUnicode().HasMaxLength(250);
            builder.Property(x => x.SeoPageTitle).IsRequired().IsUnicode(false).HasMaxLength(158);
            builder.Property(x => x.SeoAlias).IsRequired().IsUnicode(false).HasMaxLength(158);
            builder.Property(x => x.SeoDescription).IsRequired().IsUnicode(false).HasMaxLength(158);
            builder.Property(x => x.SeoKeyWord).IsRequired().IsUnicode(false).HasMaxLength(158);

        }
    }
}
