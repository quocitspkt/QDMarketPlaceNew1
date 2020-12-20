using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    public class Post 
    {
        public int Id { get; set; }
        //[Required]
        public Guid OwnerId { get; set; }

        public int ProductId { get; set; }

        //[StringLength(250)]

        public string Name { get; set; }

        //[StringLength(500)]

        public string Description { get; set; }


        public string Content { get; set; }

        //[StringLength(250)]

        public string Thumbnail { get; set; }

        //[StringLength(250)]

        public string Image { get; set; }

        //[StringLength(50)]

        public string ImageCaption { get; set; }

        public DateTime PublishedDate { get; set; }

        //[StringLength(250)]

        public string Source { get; set; }

        public DateTime Hotdate { get; set; }

        public DateTime NewDate { get; set; }

        //[StringLength(250)]

        public string SeoPageTitle { get; set; }

        //[StringLength(250)]

        public string SeoAlias { get; set; }

        //[StringLength(158)]

        public string SeoKeyWord { get; set; }

        //[StringLength(158)]

        public string SeoDescription { get; set; }
        public bool IsDeleted { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        //[ForeignKey("OwnerId")]
        //public virtual AppUser AppUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<PostInCategory> PostInCategories { get; set; }
        public ICollection<PostInTag> PostInTags { get; set; }
    }
}
