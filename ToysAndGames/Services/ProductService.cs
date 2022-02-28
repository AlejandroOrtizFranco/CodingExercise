using System.Data.Entity.Migrations;
using ToysAndGames.DbContext;
using ToysAndGames.Interfaces;
using ToysAndGames.Models;

namespace ToysAndGames.Services
{
    public class ProductService : IProductService
    {
        private readonly ToysAndGamesContext _context;

        public ProductService(ToysAndGamesContext context)
        {
            _context = context;
        }
        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public void CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void DeleteProduct(int productId)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            _context.Products.Remove(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            var productToUpdate = _context.Products.FirstOrDefault(x => product.Id == x.Id );
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.AgeRestriction = product.AgeRestriction;
            productToUpdate.Company = product.Company;
            _context.SaveChanges();
        }
    }
}
