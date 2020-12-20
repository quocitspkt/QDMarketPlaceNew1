using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class AttributeValue 
    {
        public int Id { get; set; }
        public int AttributeId { get; set; }

        //[StringLength(128)]

        public string Name { get; set; }

        public CustomAttribute CustomAttribute { get; set; }
        public ICollection<ProductAttribute> ProductAttributes { get; set; }
    }
}
