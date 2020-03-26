using HealthyLife.Models;
using HealthyLife.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HealthyLife.Wasm.Pages
{
    public partial class Ingredients
    {
        [Inject]
        private HealthyLifeOdataApiService Api { get; set; }
        [Inject]
        private NotificationService NotificationService { get; set; }

        private IEnumerable<IngredientModel> ingredients;
        private int ingredientCount;

        protected async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                var response = await Api.GetIngredientsAsync(
                    filter: $"{args.Filter}", top: args.Top, skip: args.Skip, orderby: $"{args.OrderBy}",
                    count: args.Top != null && args.Skip != null);
                ingredients = response.Value.AsODataEnumerable();
                ingredientCount = response.Count;
            }
            catch (Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Unable to Load Ingredients");
            }
        }
    }
}
