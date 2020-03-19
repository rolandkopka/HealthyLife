using HealthyLife.Domain.Food;
using Microsoft.EntityFrameworkCore;

namespace HealthyLife.Data
{
    public class FoodContext : DbContext
    {
        public DbSet<Ingredient> MyProperty { get; set; }
    }
}
