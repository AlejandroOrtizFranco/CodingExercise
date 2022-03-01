using System.Data.Entity.Migrations;
using Microsoft.EntityFrameworkCore;
using ToysAndGames.DbContext;
using ToysAndGames.Dtos;
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
        public async Task<List<ProductDto>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();

            var productsDto = products.Select(p => new ProductDto
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                AgeRestriction = p.AgeRestriction,
                Company = p.Company,
                Price = p.Price
            });

            return productsDto.ToList();
        }

        public async Task<int> CreateProduct(ProductDto product)
        {
            var newProduct = new Product
            {
                Name = product.Name,
                Description = product.Description,
                AgeRestriction = product.AgeRestriction,
                Company = product.Company,
                Price = product.Price
            };
            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();
            return product.Id;
        }

        public async Task DeleteProduct(int productId)
        {
            var product = await _context.Products.SingleOrDefaultAsync(p => p.Id == productId);
            if (product is null)
            {
                throw new ArgumentNullException();
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(ProductDto product)
        {
            var productToUpdate = _context.Products.SingleOrDefault(x => product.Id == x.Id );
            if (product is null)
            {
                throw new ArgumentNullException();
            }
            productToUpdate.Name = product.Name;
            productToUpdate.Description = product.Description;
            productToUpdate.Price = product.Price;
            productToUpdate.AgeRestriction = product.AgeRestriction;
            productToUpdate.Company = product.Company;
            await _context.SaveChangesAsync();
        }
    }
}
