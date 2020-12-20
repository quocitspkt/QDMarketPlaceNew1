using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
   
    public class Tag 
    {
        public string Id { get; set; }
        //[StringLength(250)]

        public string Name { get; set; }
        public ICollection<PostInTag> PostInTags { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
