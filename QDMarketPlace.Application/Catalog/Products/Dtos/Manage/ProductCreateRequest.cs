﻿using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Application.Catalog.Products.Dtos.Manage
{
    public class ProductCreateRequest
    {
        public decimal Price { set; get; }
        public decimal OriginalPrice { set; get; }
        public int Stock { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoPageTitle { set; get; }

        public string SeoAlias { get; set; }

    }
}
