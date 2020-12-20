using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class ProductAttribute 
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AttributeValueId { get; set; }

        public Product Product { get; set; }
        public AttributeValue AttributeValue { get; set; }
    }
}
