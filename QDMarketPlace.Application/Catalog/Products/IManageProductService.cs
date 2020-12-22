using Microsoft.AspNetCore.Http;
using QDMarketPlace.Data.Entities;
using QDMarketPlace.ViewModels.Catalog.Common;
using QDMarketPlace.ViewModels.Catalog.ProductImages;
using QDMarketPlace.ViewModels.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QDMarketPlace.Application.Catalog.Products
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);

        Task<int> Update(ProductUpdateRequest request);

        Task<int> Delete(int productId);

        Task<ProductViewModel> GetById(int productId);

        Task<bool> UpdatePrice(int productId, decimal newPrice);

        //Task<bool> UpdateStock(int productId, int addedQuantity);

        Task AddViewcount(int productId);

        Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);

        Task<int> AddImage(int productId, ProductImageCreateRequest request);

        Task<bool> InsertProductInCategory(int productId, int categoryId);

        Task<int> RemoveImage(int imageId);

        Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request);

        Task<ProductImageViewModel> GetImageById(int imageId);

        Task<List<ProductImageViewModel>> GetListImages(int productId);
    }
}