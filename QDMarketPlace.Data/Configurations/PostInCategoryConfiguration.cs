using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class PostInCategoryConfiguration : IEntityTypeConfiguration<PostInCategory>
    {
        public void Configure(EntityTypeBuilder<PostInCategory> builder)
        {
            builder.ToTable("PostInCategories");
            builder.HasKey(x => new {x.CategoryId,x.PostId });
            builder.HasOne(x => x.Post).WithMany(x => x.PostInCategories).HasForeignKey(x => x.PostId);
            builder.HasOne(x => x.PostCategory).WithMany(x => x.PostInCategories).HasForeignKey(x => x.CategoryId);



        }
    }
}
