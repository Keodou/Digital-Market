using DigitalMarket.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalMarket.Data
{
    public class DigitalMarketDbContext : DbContext
    {
        public DigitalMarketDbContext(DbContextOptions<DigitalMarketDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 1,
                ProductName = "Valheim",
                Seller = "Iron Gate",
                Description = "Игра в жанре выживание, в которой вам предстоит исследовать огромный фэнтезийный мир, пропитанный скандинавской мифологией и культурой викингов.",
                Price = 450M,
                Category = "Games"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 2,
                ProductName = "Sea of Thieves",
                Seller = "Rare Studio",
                Description = "Кооперативная многопользовательская компьютерная игра в жанре приключенческого боевика с пиратской тематикой, разработанная компанией Rare и издаваемая Microsoft Studios.",
                Price = 700M,
                Category = "Games"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 3,
                ProductName = "Grand Theft Auto 5",
                Seller = "Rockstar North",
                Description = "Мультиплатформенная компьютерная игра в жанре action-adventure с открытым миром",
                Price = 700M,
                Category = "Games"
            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductID = 4,
                ProductName = "Grand Theft Auto: San Andreas",
                Seller = "Rockstar North",
                Description = "Компьютерная игра в жанре action-adventure, разработанная студией Rockstar North",
                Price = 250M,
                Category = "Games"
            });
        }
    }
}
