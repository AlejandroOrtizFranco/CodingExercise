using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using ToysAndGames.DbContext;
using ToysAndGames.Dtos;
using ToysAndGames.Models;
using ToysAndGames.Services;
using Xunit;

namespace ToysAndGames.Tests
{
    public class ProductServiceTests : IClassFixture<ProductServiceFixture>
    {
        private readonly ProductServiceFixture _productService;

        public ToysAndGamesContext Context =>
            _productService.Context;

        private ProductService Service =>
            _productService.Service;

        public ProductServiceTests(ProductServiceFixture fixture)
        {
            _productService = fixture;
        }
        [Fact]
        public async Task GetProducts_ShouldReturn_ListOfProducts()
        {
            var result = await Service.GetProducts();
            Assert.IsType<List<ProductDto>>(result);
        }

        [Fact]
        public async Task GetProducts_ShouldNotBeEmpty()
        {
            var result = await Service.GetProducts();
            Assert.NotEmpty(result);
        }


        [Fact]
        public async Task CreateProduct_ShouldAddProduct_ToContext()
        {
            var count = Context.Products.Count();
            var newProduct = new ProductDto
                { Name = "Test Toy", Description = "Test", AgeRestriction = 12, Company = "xUnit", Price = 20M };

            await Service.CreateProduct(newProduct);
            var newCount = Context.Products.Count();

            Assert.NotEqual(count,newCount);
        }

        [Fact]
        public async Task UpdateProduct_ShouldUpdateProduct_InContext()
        {
            var productToUpdate = Context.Products.First();

            productToUpdate.Name = "Barbie Test";
            productToUpdate.Description = "Test";

            var product = new ProductDto
            {
                Id = productToUpdate.Id,
                Name = productToUpdate.Name,
                Description = productToUpdate.Description,
                AgeRestriction = productToUpdate.AgeRestriction,
                Company = productToUpdate.Company,
                Price = productToUpdate.Price
            };

            await Service.UpdateProduct(product);

            var updatedProduct = Context.Products.First();

            Assert.Equal(productToUpdate,updatedProduct);
        }

        [Fact]
        public async Task DeleteProduct_ShouldDeleteProduct_InContext()
        {
            var count = Context.Products.Count();
            var productToDelete = Context.Products.First();

            await Service.DeleteProduct(productToDelete.Id);
            var newCount = Context.Products.Count();

            Assert.NotEqual(count,newCount);
        }
    }
}