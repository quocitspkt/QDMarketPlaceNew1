using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Data.Entities
{
    public class ProductTranslation
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoPageTitle { set; get; }

        public string SeoAlias { get; set; }
        
        public Product Product { get; set; }
    }
}
