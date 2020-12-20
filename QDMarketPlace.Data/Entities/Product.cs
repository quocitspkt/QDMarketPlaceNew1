using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("Products")]
    public class Product 
    {
        [Required]
        [StringLength(128)]

        public string Name { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [StringLength(250)]

        public string Description { get; set; }


        public string Content { get; set; }

        [Required]
        [DefaultValue(0)]
        public decimal Price { get; set; }

        public decimal? PromotionPrice { get; set; }

        [Required]
        public decimal OriginalPrice { get; set; }

        [StringLength(255)]
        public string Image { get; set; }

        [StringLength(255)]
        public string ThumbImage { get; set; }

        [StringLength(255)]
        public string ImageList { get; set; }

        public int? ViewCount { get; set; }

        public int Varranty { get; set; }

        [StringLength(255)]
        public string Video { get; set; }

        public int UserCreated { get; set; }

        public int UserModified { get; set; }

        public int ShopId { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        [StringLength(128)]
        public string SeoPageTitle { get; set; }

        [StringLength(128)]
        public string SeoAlias { get; set; }

        [StringLength(158)]
        public string SeoKeyWord { get; set; }

        [StringLength(158)]
        public string SeoDescription { get; set; }

        public bool IsDeleted { get; set; }

        public int SortOrder { get; set; }


        public Status Status { get; set; }

        public Guid OwnerId { get; set; }

        [ForeignKey("CategoryId")]
        public virtual ProductCategory ProductCategory { get; set; }

    }
}
