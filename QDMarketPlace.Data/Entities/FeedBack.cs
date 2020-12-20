using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("FeedBacks")]
    public class FeedBack 
    {
        public int ProductId { get; set; }


        public string Content { get; set; }

        public bool Positive { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public Guid OwnerId { get; set; }

        public Status Status { get; set; }

        [ForeignKey("OwnerId")]
        public virtual AppUser AppUser { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
    }
}
