using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class Shop 
    {
        public int Id { get; set; }
        //[StringLength(250)]

        public string Name { get; set; }


        public string Description { get; set; }

        //[StringLength(250)]

        public string Image { get; set; }

        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        public int Rate { get; set; }
        public int Warning { get; set; }
        public bool Deposit { get; set; }
        public Status Status { get; set; }
        public Guid OwnerId { get; set; }

        //[ForeignKey("OwnerId")]
        //public virtual AppUser AppUser { get; set; }
        public ICollection<Certificate> Certificates { get; set; }

    }
}
