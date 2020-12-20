using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class CustomAttributeConfiguration : IEntityTypeConfiguration<CustomAttribute>
    {
        public void Configure(EntityTypeBuilder<CustomAttribute> builder)
        {
            builder.ToTable("CustomAttributes");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();


        }
    }
}
