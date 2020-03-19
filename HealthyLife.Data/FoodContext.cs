using HealthyLife.Domain.Food;
using Microsoft.EntityFrameworkCore;

namespace HealthyLife.Data
{
    public class FoodContext : DbContext
    {
        public DbSet<Ingredient> Ingredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ingredient>().HasData(
                new Ingredient { Name = "Salt"},
                new Ingredient { Name = "Pepper"});
        }
    }
}
