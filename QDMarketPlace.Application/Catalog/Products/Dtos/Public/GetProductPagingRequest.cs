﻿using QDMarketPlace.Application.Catalog.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace QDMarketPlace.Application.Catalog.Products.Dtos.Public
{
    public class GetProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}