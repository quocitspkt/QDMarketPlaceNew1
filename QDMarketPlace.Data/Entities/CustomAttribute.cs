using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("CustomAttributes")]
    public class CustomAttribute 
    {
        [StringLength(128)]

        public string Name { get; set; }

    }
}
