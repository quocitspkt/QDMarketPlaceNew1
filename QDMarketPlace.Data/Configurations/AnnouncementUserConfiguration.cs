using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class AnnouncementUserConfiguration : IEntityTypeConfiguration<AnnouncementUser>
    {
        public void Configure(EntityTypeBuilder<AnnouncementUser> builder)
        {
            builder.ToTable("AnnouncementUsers");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.AnnouncementId).IsRequired();
            builder.HasOne(x => x.Announcement).WithMany(x => x.AnnouncementUsers).HasForeignKey(x => x.AnnouncementId);

        }
    }
}
