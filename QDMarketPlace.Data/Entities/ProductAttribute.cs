using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("ProductAttributes")]
    public class ProductAttribute 
    {
        public int ProductId { get; set; }
        public int AttributeValueId { get; set; }

        public virtual Product Product { get; set; }
        public virtual AttributeValue AttributeValue { get; set; }
    }
}
