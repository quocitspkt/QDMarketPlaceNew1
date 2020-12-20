using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("Certificates")]
    public class Certificate 
    {
        [StringLength(250)]
        [Required]
        public string Name { get; set; }
        public int ShopId { get; set; }
        [StringLength(250)]
        public string Image { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public Status Status { get; set; }

        [ForeignKey("ShopId")]
        public virtual Shop Shop { get; set; }
    }
}
