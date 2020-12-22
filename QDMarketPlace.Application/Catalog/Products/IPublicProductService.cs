using QDMarketPlace.ViewModels.Catalog.Common;
using QDMarketPlace.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QDMarketPlace.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);

        Task<List<ProductViewModel>> GetAll();
    }
}