using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("Orders")]
    public class Order
    {

        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }

        public Status Status { get; set; }

        [ForeignKey("CustomerId")]
        public virtual AppUser AppUser { get; set; }
    }
}
