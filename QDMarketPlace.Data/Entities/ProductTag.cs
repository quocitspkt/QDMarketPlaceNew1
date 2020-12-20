using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("ProductTags")]
    public class ProductTag 
    {
        public int ProductId { get; set; }
        [StringLength(50)]

        public string TagId { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { set; get; }
        [ForeignKey("TagId")]
        public virtual Tag Tag { get; set; }
    }
}
