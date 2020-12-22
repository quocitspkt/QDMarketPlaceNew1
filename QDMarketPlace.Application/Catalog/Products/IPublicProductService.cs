using QDMarketPlace.Application.Catalog.Dtos;
using QDMarketPlace.Application.Catalog.Products.Dtos;
using QDMarketPlace.Application.Catalog.Products.Dtos.Public;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace QDMarketPlace.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProductPagingRequest request);
    }
}

