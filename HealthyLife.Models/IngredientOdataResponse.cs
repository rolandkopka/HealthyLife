using HealthyLife.Domain.Food;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyLife.Models
{
    public class IngredientOdataResponse
    {
        [JsonProperty("@odata.context")]
        public string ODataContext { get; set; }
        [JsonProperty("value")]
        public List<Ingredient> Ingredients { get; set; }
    }
}
