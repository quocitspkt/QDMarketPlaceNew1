using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("PostInCategories")]
    public class PostInCategory 
    {
        public int PostId { get; set; }
        public int CategoryId { get; set; }

        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        [ForeignKey("CategoryId")]
        public virtual PostCategory PostCategory { get; set; }
    }
}
