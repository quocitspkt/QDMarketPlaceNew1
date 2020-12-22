using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QDMarketPlace.Application.Common;
using QDMarketPlace.Data.EF;
using QDMarketPlace.Data.Entities;
using QDMarketPlace.Utilities.Exceptions;
using QDMarketPlace.ViewModels.Catalog.Common;
using QDMarketPlace.ViewModels.Catalog.ProductImages;
using QDMarketPlace.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QDMarketPlace.Application.Catalog.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly QDMarketPlaceDbContext _context;
        private readonly IStorageService _storageService;

        public ManageProductService(QDMarketPlaceDbContext context, IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewcount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount += 1;
            await _context.SaveChangesAsync();
        }

        public async Task<int> Create(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Name = request.Name,
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                DateCreated = DateTime.Now,
                Image = "null",
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name =  request.Name,
                        Description = request.Description,
                        Details = request.Details,
                        SeoDescription = request.SeoDescription,
                        SeoAlias = request.SeoAlias,
                        SeoPageTitle = request.SeoPageTitle,
                    }
                }
            };
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        DateCreated = DateTime.Now,
                        FileSize = request.ThumbnailImage.Length,
                        ImagePath = await this.SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                        SortOrder = 1
                    }
                };
            }
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product.Id;
            
        }

        public async Task<bool> InsertProductInCategory(int productId, int categoryId)
        {
            var productInCategory = new ProductInCategory()
            {
                ProductId = productId,
                CategoryId = categoryId
            };
           
            _context.ProductInCategories.Add(productInCategory);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<int> Delete(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new QDMarketException($"Cannot find a product: {productId}");

            var images = _context.ProductImages.Where(i => i.ProductId == productId);
            foreach (var image in images)
            {
                await _storageService.DeleteFileAsync(image.ImagePath);
            }

            _context.Products.Remove(product);

            return await _context.SaveChangesAsync();

            
        }

        public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
        {
            //1. Select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.ProductCategories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            //2. filter
            if (!string.IsNullOrEmpty(request.Keyword))
                query = query.Where(x => x.pt.Name.Contains(request.Keyword));

            if (request.CategoryIds.Count > 0)
            {
                query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
            }
            //3. Paging
            int totalRow = await query.CountAsync();

            var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
                .Take(request.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,

                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoPageTitle = x.pt.SeoPageTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    Image = "null"
                }).ToListAsync();

            ////4. Select and projection
            var pagedResult = new PagedResult<ProductViewModel>()
            {
                //TotalRecord = totalRow,
                //Items = data
            };
            return pagedResult;
        }

        public async Task<ProductViewModel> GetById(int productId)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.ProductInCategories on p.Id equals pic.ProductId
                        join c in _context.ProductCategories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };

            query = query.Where(x => x.p.Id == productId);
            var data = await query.Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.DateCreated,
                    Description = x.pt.Description,
                    Details = x.pt.Details,

                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoPageTitle = x.pt.SeoPageTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount,
                    Image = "null"
            }).FirstOrDefaultAsync();

            return data;
        }

        public async Task<int> Update(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            );

            if (product == null || productTranslations == null) throw new QDMarketException($"Cannot find a product with id: {request.Id}");
            product.Name = request.Name;
            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoPageTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;

            //Save image
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.FileSize = request.ThumbnailImage.Length;
                    thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }

            return await _context.SaveChangesAsync();
            
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new QDMarketException($"Cannot find a product with id: {productId}");
            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int addedQuantity)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new QDMarketException($"Cannot find a product with id: {productId}");
            product.Stock += addedQuantity;
            return await _context.SaveChangesAsync() > 0;
        }
        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
        {
            var productImge = new ProductImage()
            {
                Caption = request.Caption,
                DateCreated = DateTime.Now,
                IsDefault = request.IsDefault,
                ProductId = productId,
                SortOrder = request.SortOrder
            };

            if (request.ImageFile != null)
            {
                productImge.FileSize = request.ImageFile.Length;
                productImge.ImagePath = await this.SaveFile(request.ImageFile);
            }
            _context.ProductImages.Add(productImge);
            await _context.SaveChangesAsync();
            return productImge.Id;
        }

        public async Task<int> RemoveImage(int imageId)
        {
            var productImge = await _context.ProductImages.FindAsync(imageId);

            if (productImge == null)
            {
                throw new QDMarketException($"Cannot find the image with id {imageId}");
            }

            _context.ProductImages.Remove(productImge);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
        {
            var productImge = await _context.ProductImages.FindAsync(imageId);

            if (productImge == null)
            {
                throw new QDMarketException($"Cannot find the image with id {imageId}");
            }

            productImge.Caption = request.Caption;
            productImge.IsDefault = request.IsDefault;
            productImge.SortOrder = request.SortOrder;

            if (request.ImageFile != null)
            {
                productImge.FileSize = request.ImageFile.Length;
                productImge.ImagePath = await this.SaveFile(request.ImageFile);
            }
            _context.ProductImages.Update(productImge);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<ProductImageViewModel>> GetListImages(int productId)
        {
            return await _context.ProductImages.Where(x => x.ProductId == productId)
                .Select(i => new ProductImageViewModel()
                {
                    Caption = i.Caption,
                    DateCreated = i.DateCreated,
                    FileSize = i.FileSize,
                    Id = i.Id,
                    ImagePath = i.ImagePath,
                    IsDefault = i.IsDefault,
                    ProductId = i.ProductId,
                    SortOrder = i.SortOrder
                }).ToListAsync();
        }

        public async Task<ProductImageViewModel> GetImageById(int imageId)
        {
            var productImage = await _context.ProductImages.FindAsync(imageId);
           
            if (productImage == null)
            {
                throw new QDMarketException($"Cannot find the image with id {imageId}");
            }
            var image = new ProductImageViewModel()
                {
                    Caption = productImage.Caption,
                    DateCreated = productImage.DateCreated,
                    FileSize = productImage.FileSize,
                    Id = productImage.Id,
                    ImagePath = productImage.ImagePath,
                    IsDefault = productImage.IsDefault,
                    ProductId = productImage.ProductId,
                    SortOrder = productImage.SortOrder
                };
            return image;
        }
    }
}