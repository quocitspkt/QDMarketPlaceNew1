﻿using QDMarketPlace.Application.Catalog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Application.Catalog.Products.Dtos.Manage
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }

        public List<int> CategoryIds { get; set; }

    }
}
