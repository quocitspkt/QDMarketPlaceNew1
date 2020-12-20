using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("AttributeValues")]
    public class AttributeValue 
    { 
        public int AttributeId { get; set; }

        [StringLength(128)]

        public string Name { get; set; }

        public virtual CustomAttribute CustomAttribute { get; set; }
    }
}
