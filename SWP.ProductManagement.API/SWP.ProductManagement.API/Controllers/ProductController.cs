using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SWP.ProductManagement.API.RequestModel;
using SWP.ProductManagement.API.ResponseModel;
using SWP.ProductManagement.Service.BusinessModel;
using SWP.ProductManagement.Service.Services;

namespace SWP.ProductManagement.API.Controllers
{
    [Route("api/")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("products")]
        public async Task<ActionResult<IEnumerable<ProductResponseModel>>> GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            var response = products.Select(product => new ProductResponseModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice
            });

            return Ok(response);
        }

        [HttpGet("products/{id}")]
        public async Task<ActionResult<ProductResponseModel>> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null) return NotFound();

            var response = new ProductResponseModel
            {
                ProductId = product.ProductId,
                ProductName = product.ProductName,
                UnitsInStock = product.UnitsInStock,
                UnitPrice = product.UnitPrice
            };

            return Ok(response);
        }

        [HttpPost("products")]
        public async Task<ActionResult> CreateProduct(ProductRequestModel request)
        {
            var productModel = new ProductModel
            {
                ProductName = request.ProductName,
                UnitsInStock = request.UnitsInStock,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId
            };

            var rs = await _productService.InsertProductAsync(productModel);
            productModel.ProductId = rs;
            return CreatedAtAction(nameof(GetProductById), new { id = productModel.ProductId }, productModel);
        }

        [HttpPut("products/{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductRequestModel request)
        {
            var productModel = new ProductModel
            {
                ProductName = request.ProductName,
                UnitsInStock = request.UnitsInStock,
                UnitPrice = request.UnitPrice,
                CategoryId = request.CategoryId
            };

            var success = await _productService.UpdateProductAsync(id, productModel);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var success = await _productService.DeleteProductAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
