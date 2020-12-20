using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comments");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Post).WithMany(x => x.Comments).HasForeignKey(x => x.PostId);
            builder.Property(x => x.Email).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Phone).HasMaxLength(50).IsRequired();


        }
    }
}
