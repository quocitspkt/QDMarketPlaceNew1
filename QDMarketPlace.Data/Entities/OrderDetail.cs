using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("OrderDetails")]
    public class OrderDetail 
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
