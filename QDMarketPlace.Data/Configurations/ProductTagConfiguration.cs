using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.ToTable("ProductTags");
            builder.HasKey(x => new {x.ProductId,x.TagId });
            builder.HasOne(x => x.Product).WithMany(x => x.ProductTags).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.Tag).WithMany(x => x.ProductTags).HasForeignKey(x => x.TagId);



        }
    }
}
