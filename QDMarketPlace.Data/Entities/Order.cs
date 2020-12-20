using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }

        public Status Status { get; set; }

        //[ForeignKey("CustomerId")]
        //public virtual AppUser AppUser { get; set; }

        public ICollection<ChatSession> ChatSessions { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
