using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class CustomAttribute 
    {
        public int Id { get; set; }
        //[StringLength(128)]

        public string Name { get; set; }
        public ICollection<AttributeValue> AttributeValues { get; set; }

    }
}
