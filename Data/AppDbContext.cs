using Microsoft.EntityFrameworkCore;
using ChallengePPI.Backend.Models;

namespace ChallengePPI.Backend.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Asset> Assets { get; set; }
        public DbSet<OrderState> OrderStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderState>().HasData(
                new OrderState { Id = 0, Description = "En proceso" },
                new OrderState { Id = 1, Description = "Ejecutada" },
                new OrderState { Id = 2, Description = "Cancelada" }
            );

            modelBuilder.Entity<Asset>().HasData(
                new Asset { Id = 1, Ticker = "AAPL", Name = "Apple", AssetType = 1, UnitPrice = 177.97m },
                new Asset { Id = 2, Ticker = "GOOGL", Name = "Alphabet Inc", AssetType = 1, UnitPrice = 138.21m },
                new Asset { Id = 6, Ticker = "AL30", Name = "BONOS ARGENTINA USD 2030 L.A", AssetType = 2, UnitPrice = 307.4m }
            );
        }
    }
}