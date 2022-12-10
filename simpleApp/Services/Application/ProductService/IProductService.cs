using simpleApp.Models;
using simpleApp.Services.Application.ProductService.DTOs;

namespace simpleApp.Services.Application.ProductService
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(int id);
        Product CreateProduct(CreateProductRequest request);
        bool DeleteProduct(int id);
    }
}
