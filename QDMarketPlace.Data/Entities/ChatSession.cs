using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class ChatSession 
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }

        public int SellerId { get; set; }

        public int AdminId { get; set; }


        public string Content { get; set; }

        public int ProductId { get; set; }

        public bool Report { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Status Status { get; set; }

        public int OrderId { get; set; }
        //[ForeignKey("OrderId")]
        public Order Order { get; set; }

        //[ForeignKey("ProductId")]
        public Product Product { get; set; }



    }
}
