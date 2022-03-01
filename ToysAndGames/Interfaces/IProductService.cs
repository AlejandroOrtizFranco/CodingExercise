using ToysAndGames.Dtos;
using ToysAndGames.Models;

namespace ToysAndGames.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<int> CreateProduct(ProductDto product);
        Task DeleteProduct(int productId);
        Task UpdateProduct(ProductDto product);
    }
}
