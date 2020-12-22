using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QDMarketPlace.Application.Catalog.Products;
using QDMarketPlace.ViewModels.Catalog.ProductImages;
using QDMarketPlace.ViewModels.Catalog.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QDMarketPlace.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IPublicProductService _publicProductService;
        private readonly IManageProductService _manageProductService;


        public ProductController(IPublicProductService publicProductService, IManageProductService manageProductService)
        {
            _publicProductService = publicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _publicProductService.GetAll();

            return Ok(products);
        }

        [HttpGet("public-paging")]
        public async Task<IActionResult> Get([FromQuery] GetPublicProductPagingRequest request)
        {
            var products = await _publicProductService.GetAllByCategoryId(request);

            return Ok(products);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetByID(int productId)
        {
            var product = await _manageProductService.GetById(productId);
            if (product == null)
                return BadRequest("Cannot find the product!");
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromForm] ProductCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productId = await _manageProductService.Create(request);
            if (productId == 0)
                return BadRequest();
            var product = await _manageProductService.GetById(productId);
            var isSuccessProductInCategory = await _manageProductService.InsertProductInCategory(productId, 1);
            return CreatedAtAction(nameof(GetByID), new { id = productId }, product);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var affectedResilt = await _manageProductService.Update(request);
            if (affectedResilt == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> Delete(int productId)
        {
            var affectedResilt = await _manageProductService.Delete(productId);
            if (affectedResilt == 0)
                return BadRequest();
            return Ok();
        }

        [HttpPatch("{productId}/{newprice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newprice)
        {
            var isSuccessful = await _manageProductService.UpdatePrice(productId, newprice);
            if (isSuccessful)
                return Ok();
            return BadRequest();
        }
        
        [HttpPost("{productId}/images")]
        public async Task<IActionResult> CreateImage(int productId, [FromForm] ProductImageCreateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var productImageId = await _manageProductService.AddImage(productId, request);
            if (productImageId == 0)
                return BadRequest();
            var productImage = await _manageProductService.GetById(productImageId);
            return CreatedAtAction(nameof(GetImageByID), new { id = productImageId }, productImage);
        }

        [HttpPut("{productId}/images/{imageId}")]
        public async Task<IActionResult> UpdateImage(int imageId, [FromForm] ProductImageUpdateRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.UpdateImage(imageId, request);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpDelete("{productId}/images/{imageId}")]
        public async Task<IActionResult> DeleteImage(int imageId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var result = await _manageProductService.RemoveImage(imageId);
            if (result == 0)
                return BadRequest();
            return Ok();
        }

        [HttpGet("{productId}/images/{imageId}")]
        public async Task<IActionResult> GetImageByID(int productId, int imageId)
        {
            var image = await _manageProductService.GetImageById(imageId);
            if (image == null)
                return BadRequest("Cannot find the product!");
            return Ok(image);
        }
    }
}
