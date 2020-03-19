using HealthyLife.Domain.Food;
using Microsoft.EntityFrameworkCore;

namespace HealthyLife.Data
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Id = 1, Name = "Salt"},
                new Ingredient { Id = 2, Name = "Pepper"});
        }
    }
}
