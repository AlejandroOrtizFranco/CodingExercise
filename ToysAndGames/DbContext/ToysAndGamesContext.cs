
using Microsoft.EntityFrameworkCore;
using ToysAndGames.Models;

namespace ToysAndGames.DbContext
{
    public class ToysAndGamesContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public ToysAndGamesContext(DbContextOptions<ToysAndGamesContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(new
                {
                    Id=1,
                    Name = "Barbie",
                    Description = "Doll",
                    AgeRestriction = 12,
                    Company = "Mattel",
                    Price = 25.99M
                }, new
                {
                    Id=2,
                    Name = "Max Steel",
                    Description = "Action figure",
                    AgeRestriction = 12,
                    Company = "Mattel",
                    Price = 19.99M
                },
                new
                {
                    Id=3,
                    Name = "GIJoe",
                    Description = "Action figure",
                    AgeRestriction = 12,
                    Company = "Hasbro",
                    Price = 14.99M
                });
        }
    }
}