using HealthyLife.Data.Entities.Food;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace HealthyLife.Data.DbContexts
{
    public class FoodContext : DbContext
    {
        public FoodContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seeding
            var i_egg = new Ingredient { Id = 1, Name = "Large Egg", Calory = 143, Carbohydrate = 0.7, Fat = 9.5, Protein = 13 };
            var i_salt = new Ingredient { Id = 2, Name = "Salt", Calory = 0, Carbohydrate = 0, Fat = 0, Protein = 0 };
            modelBuilder.Entity<Ingredient>().HasData(i_egg, i_salt);

            var r_friedEgg = new Recipe { Id = 1, Title = "Fried Egg", Servings = 1, ReadyInMinutes = 5, Picture = "https://pixabay.com/get/55e6d7474350a914f6d1867dda6d49214b6ac3e45659754e762f7cd095/fried-3624925_1920.jpg", Instructions = "Crack the eggs into the hot pan and salt them. Cook both sides of the eggs for 2-2 minutes." };
            modelBuilder.Entity<Recipe>().HasData(r_friedEgg);

            var re_eggs = new RecipeIngredient { Id = 1, IngredientId = 1, Amount = 4, Unit = "", RecipeId = 1 };
            var re_salt = new RecipeIngredient { Id = 2, IngredientId = 2, Amount = 0.5, Unit = "tsp", RecipeId = 1 };
            modelBuilder.Entity<RecipeIngredient>().HasData(re_eggs, re_salt);
        }
    }
}
