using QDMarketPlace.ViewModels.Catalog.Common;
using QDMarketPlace.ViewModels.Catalog.Products;
using System.Threading.Tasks;

namespace QDMarketPlace.Application.Catalog.Products
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetPublicProductPagingRequest request);
    }
}