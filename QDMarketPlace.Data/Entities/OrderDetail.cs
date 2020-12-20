﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    public class OrderDetail 
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }

        //[ForeignKey("OrderId")]
        public Order Order { get; set; }
        //[ForeignKey("ProductId")]
        public Product Product { get; set; }
    }
}
