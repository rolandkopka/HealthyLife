﻿namespace HealthyLife.Data.Entities.Food
{
    /// <summary>
    /// This is a raw ingredient
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Nutritions
        // Everything is measured in 100 g
        public double Calory { get; set; } // kcal
        public double Carbohydrate { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
    }
}
