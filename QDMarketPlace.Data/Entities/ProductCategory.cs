using QDMarketPlace.Data.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    
    public class ProductCategory 
    {
        
        
        public int Id { get; set; }

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

        public  ICollection<Product> Products { set; get; }
        public ICollection<ProductInCategory> ProductInCategories { get; set; }
    }
}
