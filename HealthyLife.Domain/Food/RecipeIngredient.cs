using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyLife.Domain.Food
{
    /// <summary>
    /// This is an ingredient in a recipe with measurements
    /// </summary>
    public class RecipeIngredient
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Unit { get; set; }

        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }

        public int RecipeId { get; set; }
        public Recipe Recipe { get; set; }
    }
}
