using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class PostCategoryConfiguration : IEntityTypeConfiguration<PostCategory>
    {
        public void Configure(EntityTypeBuilder<PostCategory> builder)
        {
            builder.ToTable("PostCategories");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(250).IsUnicode();
            builder.Property(x => x.SeoPageTitle).HasMaxLength(158).IsUnicode(false);
            builder.Property(x => x.SeoAlias).HasMaxLength(128).IsUnicode(false);
            builder.Property(x => x.SeoKeyWord).HasMaxLength(158).IsUnicode(false);
            builder.Property(x => x.SeoDescription).HasMaxLength(158).IsUnicode(false);



        }
    }
}
