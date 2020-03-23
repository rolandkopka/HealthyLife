using HealthyLife.Domain.Food;
using HealthyLife.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyLife.Wasm.Pages
{
    public partial class Ingredients
    {
       private List<Ingredient> ingredients;

        protected override async Task OnInitializedAsync()
        {
            var response = await Http.GetAsync("Ingredients");
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                var odataResponse = JsonConvert.DeserializeObject<IngredientOdataResponse>(jsonString);
                ingredients = odataResponse.Ingredients;
            }
        }
}
}
