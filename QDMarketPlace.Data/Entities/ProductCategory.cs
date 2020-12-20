using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    [Table("ProductCategories")]
    public class ProductCategory 
    {
        public ProductCategory()
        {
            Products = new List<Product>();
        }
        public ProductCategory(string name, string description, int? parentId, int? homeOrder, bool? homeFlag, string seoPageTitle, string seoAlias, string seoKeyWord,
            string seoDescription, Status status, DateTime dateCreated, DateTime dateModified, int sortOrder)
        {
            Name = name;
            Description = description;
            ParentId = parentId;
            HomeOrder = homeOrder;
            HomeFlag = homeFlag;
            SeoPageTitle = seoPageTitle;
            SeoAlias = seoAlias;
            SeoKeyWord = seoKeyWord;
            SeoDescription = seoDescription;
            Status = status;
            DateCreated = dateCreated;
            DateModified = dateModified;
            SortOrder = sortOrder;

        }

        public string Name { get; set; }
        public string Description { get; set; }

        public int? ParentId { get; set; }
        public int? HomeOrder { get; set; }
        public bool? HomeFlag { get; set; }


        public string SeoPageTitle { set; get; }


        public string SeoAlias { set; get; }


        public string SeoKeyWord { set; get; }


        public string SeoDescription { set; get; }

        public Status Status { set; get; }

        public DateTime DateCreated { set; get; }

        public DateTime DateModified { set; get; }

        public int SortOrder { set; get; }

        public virtual ICollection<Product> Products { set; get; }
    }
}
