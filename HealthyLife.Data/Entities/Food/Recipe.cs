using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyLife.Data.Entities.Food
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int Servings { get; set; }
        public int ReadyInMinutes { get; set; }
        public string Picture { get; set; }
        public List<RecipeIngredient> Ingredients { get; set; }
        public string Instructions { get; set; }
    }
}
