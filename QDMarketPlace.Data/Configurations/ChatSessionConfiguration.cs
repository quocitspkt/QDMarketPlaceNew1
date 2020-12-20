using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QDMarketPlace.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Configurations
{
    public class ChatSessionConfiguration : IEntityTypeConfiguration<ChatSession>
    {
        public void Configure(EntityTypeBuilder<ChatSession> builder)
        {
            builder.ToTable("ChatSessions");
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Order).WithMany(x => x.ChatSessions).HasForeignKey(x => x.OrderId);
            builder.HasOne(x => x.Product).WithMany(x => x.ChatSessions).HasForeignKey(x => x.ProductId);


        }
    }
}
