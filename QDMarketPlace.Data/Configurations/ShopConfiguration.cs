using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("Shops");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(250).IsUnicode();
            builder.Property(x => x.Description).HasMaxLength(500).IsUnicode();
            builder.HasOne(x => x.AppUser).WithMany(x => x.Shops).HasForeignKey(x => x.OwnerId);



        }
    }
}
