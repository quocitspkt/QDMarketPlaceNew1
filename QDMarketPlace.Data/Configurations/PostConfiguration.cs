using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(250).IsUnicode();
            builder.Property(x => x.Description).HasMaxLength(500).IsUnicode();
            builder.Property(x => x.Thumbnail).HasMaxLength(250);
            builder.HasOne(x => x.AppUser).WithMany(x => x.Posts).HasForeignKey(x => x.OwnerId);



        }
    }
}
