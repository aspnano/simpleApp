using Microsoft.AspNetCore.Mvc;
using simpleApp.Services.Application.ProductService;
using simpleApp.Services.Application.ProductService.DTOs;

// example CRUD style endpoint with service
namespace simpleApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService _productService; // injecting the product service

        // Dependency Injection with constructor method
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
   
        // Get list of products
        [HttpGet]
        public IActionResult Get()
        {
            var list = _productService.GetAllProducts(); // using a method from the service
            return Ok(list);
        }

        // Create a new product
        [HttpPost]
        public IActionResult Post(CreateProductRequest request)
        {
            try
            {
                var result = _productService.CreateProduct(request); // using another method from the service
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // Update product

        // Delete product
    }
}
