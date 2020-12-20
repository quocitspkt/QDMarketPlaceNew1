using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("Tags")]
    public class Tag 
    {
        [StringLength(250)]

        public string Name { get; set; }
    }
}
