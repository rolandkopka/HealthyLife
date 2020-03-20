namespace HealthyLife.Domain.Food
{
    /// <summary>
    /// This is raw a ingredient
    /// </summary>
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CaloryIn100G { get; set; }
        public double CarboHydrateIn100G { get; set; }
        public double ProteinIn100G { get; set; }
        public double FatIn100G { get; set; }
    }
}
