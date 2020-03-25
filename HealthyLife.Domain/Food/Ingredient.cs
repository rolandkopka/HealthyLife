namespace HealthyLife.Domain.Food
{
    /// <summary>
    /// This is raw a ingredient
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        // Nutritions
        // Everything is measured in 100 g
        public int Calory { get; set; } // kcal
        public double Carbohydrate { get; set; }
        public double Protein { get; set; }
        public double Fat { get; set; }
    }
}
