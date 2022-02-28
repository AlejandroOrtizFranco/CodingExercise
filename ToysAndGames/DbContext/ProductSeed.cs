using System.Data.Entity;
using ToysAndGames.Models;

namespace ToysAndGames.DbContext
{
    public class ProductSeed 

    {
        protected void Seed(ToysAndGamesContext context)
        {
            var products = new List<Product>
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

            products.ForEach(p => context.Products.Add(p));
            context.SaveChanges();
        }
    }
}
