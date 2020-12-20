using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class PostInTag 
    {
        public int PostId { get; set; }
        public string TagId { get; set; }

        //[ForeignKey("PostId")]
        public Post Post { get; set; }
        //[ForeignKey("TagId")]
        public Tag Tag { get; set; }
    }
}
