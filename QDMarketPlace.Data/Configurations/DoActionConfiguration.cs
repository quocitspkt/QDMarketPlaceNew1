using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class DoActionConfiguration : IEntityTypeConfiguration<DoAction>
    {
        public void Configure(EntityTypeBuilder<DoAction> builder)
        {
            builder.ToTable("DoActions");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Code).HasMaxLength(50);
            builder.Property(x => x.Name).HasMaxLength(50);


        }
    }
}
