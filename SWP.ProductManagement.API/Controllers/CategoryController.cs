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
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService _categoryService;

        public CategoryController(CategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("categories")]
        public async Task<ActionResult<IEnumerable<CategoryResponseModel>>> GetCategories()
        {
            var categories = await _categoryService.GetCategoriesAsync();
            var response = categories.Select(category => new CategoryResponseModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Products = category.Products.Select(product => new ProductResponseModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    UnitsInStock = product.UnitsInStock,
                    UnitPrice = product.UnitPrice,
                    CategoryName = category.CategoryName
                }).ToList()
            });

            return Ok(response);
        }

        [HttpGet("category/{id}")]
        public async Task<ActionResult<CategoryResponseModel>> GetCategoryById(int id)
        {
            var category = await _categoryService.GetCategoryByIdAsync(id);
            if (category == null) return NotFound();

            var response = new CategoryResponseModel
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                Products = category.Products.Select(product => new ProductResponseModel
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    UnitsInStock = product.UnitsInStock,
                    UnitPrice = product.UnitPrice,
                    CategoryName = category.CategoryName
                }).ToList()
            };

            return Ok(response);
        }

        [HttpPost("category")]
        public async Task<ActionResult> CreateCategory(CategoryRequestModel request)
        {
            var categoryModel = new CategoryModel
            {
                CategoryName = request.CategoryName
            };

            var rs = await _categoryService.InsertCategoryAsync(categoryModel);
            categoryModel.CategoryId = rs;
            return CreatedAtAction(nameof(GetCategoryById), new { id = categoryModel.CategoryId }, categoryModel);
        }

        [HttpPut("category/{id}")]
        public async Task<IActionResult> UpdateCategory(int id, CategoryRequestModel request)
        {
            var categoryModel = new CategoryModel
            {
                CategoryName = request.CategoryName
            };

            var success = await _categoryService.UpdateCategoryAsync(id, categoryModel);
            if (!success) return NotFound();

            return NoContent();
        }

        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var success = await _categoryService.DeleteCategoryAsync(id);
            if (!success) return NotFound();

            return NoContent();
        }
    }
}
