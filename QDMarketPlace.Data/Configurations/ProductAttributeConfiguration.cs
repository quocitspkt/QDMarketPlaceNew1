using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ProductAttributeConfiguration : IEntityTypeConfiguration<ProductAttribute>
    {
        public void Configure(EntityTypeBuilder<ProductAttribute> builder)
        {
            builder.ToTable("ProductAttributes");
            builder.HasKey(x =>x.Id);
            builder.HasOne(x => x.Product).WithMany(x => x.ProductAttributes).HasForeignKey(x => x.ProductId);
            builder.HasOne(x => x.AttributeValue).WithMany(x => x.ProductAttributes).HasForeignKey(x => x.AttributeValueId);



        }
    }
}
