using ToysAndGames.Models;

namespace ToysAndGames.Interfaces
{
    public interface IProductService
    {
        public List<Product> GetProducts();
        public void CreateProduct(Product product);
        public void DeleteProduct(int productId);
        public void UpdateProduct(Product product);
    }
}
