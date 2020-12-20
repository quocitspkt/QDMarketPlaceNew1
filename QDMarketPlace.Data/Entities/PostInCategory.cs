using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class PostInCategory 
    {
        
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        //[ForeignKey("PostId")]
        public Post Post { get; set; }

        //[ForeignKey("CategoryId")]
        public PostCategory PostCategory { get; set; }
    }
}
