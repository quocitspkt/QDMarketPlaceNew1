using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ActionInFunctionConfiguration:IEntityTypeConfiguration<ActionInFunction>
    {
        public void Configure(EntityTypeBuilder<ActionInFunction> builder)
        {
            builder.ToTable("ActionInFunctions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Function).WithMany(x => x.ActionInFunctions).HasForeignKey(x => x.FunctionId);
            builder.HasOne(x => x.DoAction).WithMany(x => x.ActionInFunctions).HasForeignKey(x => x.ActionId);
        }
    }
}
