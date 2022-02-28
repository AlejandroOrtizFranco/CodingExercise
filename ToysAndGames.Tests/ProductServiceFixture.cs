using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ToysAndGames.DbContext;
using ToysAndGames.Models;
using ToysAndGames.Services;

namespace ToysAndGames.Tests
{
    public class ProductServiceFixture: IDisposable
    {
        private DbContextOptions<ToysAndGamesContext> _options =
            new DbContextOptionsBuilder<ToysAndGamesContext>().UseInMemoryDatabase("ToysAndGamesTests").Options;

        public ToysAndGamesContext Context { get; }

        internal ProductService Service { get; }

        public ProductServiceFixture()
        {
            Context = new ToysAndGamesContext(_options);
            Context.Products.AddRange(Products);
            Context.SaveChanges();  

            Service = new ProductService(Context);
        }

        public IEnumerable<Product> Products => new List<Product>()
        {
            new()
            {
                Name = "Barbie", Description = "Doll", AgeRestriction = 12, Company = "Mattel", Price = 25.99M
            },
            new()
            {
                Name = "Max Steel", Description = "Action figure", AgeRestriction = 12, Company = "Mattel", Price = 19.99M
            },
            new()
            {
                Name = "GIJoe", Description = "Action figure", AgeRestriction = 12, Company = "Hasbro", Price = 14.99M
            },
        };

        public void Dispose()
        {
            Context.Dispose();
            _options = null;
        }
    }
}
