using System.Collections.Generic;
using System.Linq;
using Moq;
using ToysAndGames.DbContext;
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
        public void GetProducts_ShouldReturn_ListOfProducts()
        {
            var result = Service.GetProducts();
            Assert.IsType<List<Product>>(result);
        }

        [Fact]
        public void GetProducts_ShouldNotBeEmpty()
        {
            var result = Service.GetProducts();
            Assert.NotEmpty(result);
        }


        [Fact]
        public void CreateProduct_ShouldAddProduct_ToContext()
        {
            var count = Context.Products.Count();
            var newProduct = new Product
                { Name = "Test Toy", Description = "Test", AgeRestriction = 12, Company = "xUnit", Price = 20M };

            Service.CreateProduct(newProduct);
            var newCount = Context.Products.Count();

            Assert.NotEqual(count,newCount);
        }

        [Fact]
        public void UpdateProduct_ShouldUpdateProduct_InContext()
        {
            var productToUpdate = Context.Products.First();

            productToUpdate.Name = "Barbie Test";
            productToUpdate.Description = "Test";

            Service.UpdateProduct(productToUpdate);

            var updatedProduct = Context.Products.First();

            Assert.Equal(productToUpdate,updatedProduct);
        }

        [Fact]
        public void DeleteProduct_ShouldDeleteProduct_InContext()
        {
            var count = Context.Products.Count();
            var productToDelete = Context.Products.First();

            Service.DeleteProduct(productToDelete.Id);
            var newCount = Context.Products.Count();

            Assert.NotEqual(count,newCount);
        }
    }
}