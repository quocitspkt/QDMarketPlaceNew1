using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class AttributeValueConfiguration : IEntityTypeConfiguration<AttributeValue>
    {
        public void Configure(EntityTypeBuilder<AttributeValue> builder)
        {
            builder.ToTable("AttributeValues");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.CustomAttribute).WithMany(x => x.AttributeValues).HasForeignKey(x => x.AttributeId);
            builder.Property(x => x.Name).HasMaxLength(128).IsUnicode();
        }
    }
}
