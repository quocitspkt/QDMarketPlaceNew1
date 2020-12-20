using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class ProductTag 
    {
        public int ProductId { get; set; }
        //[StringLength(50)]

        public string TagId { get; set; }

        //[ForeignKey("ProductId")]
        public Product Product { set; get; }
        //[ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
