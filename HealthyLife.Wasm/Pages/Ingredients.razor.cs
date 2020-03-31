using HealthyLife.Models.Food;
using HealthyLife.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Radzen;
using Radzen.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyLife.Wasm.Pages
{
    public partial class Ingredients
    {
        [Inject]
        private HealthyLifeOdataApiService Api { get; set; }
        [Inject]
        private NotificationService NotificationService { get; set; }
        [Inject]
        private DialogService DialogService { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0044:Add readonly modifier", Justification = "<Pending>")]
        private RadzenGrid<IngredientModel> _grid;

        private IEnumerable<IngredientModel> ingredients;
        private int ingredientCount;

        protected async Task GridLoadData(LoadDataArgs args)
        {
            try
            {
                var response = await Api.GetIngredientsAsync(
                    filter: $"{args.Filter}", top: args.Top, skip: args.Skip, orderby: $"{args.OrderBy ?? "Id desc"}",
                    count: args.Top != null && args.Skip != null);
                ingredients = response.Value.AsODataEnumerable();
                ingredientCount = response.Count;
            }
            catch (Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Unable to Load Ingredients");
            }
        }
        protected async Task AddClick(MouseEventArgs args)
        {
            await DialogService.OpenAsync<AddIngredient>("Add Ingredient");
            _grid.Reload();
        }

        protected async Task DeleteClick(IngredientModel ingredient)
        {
            try
            {
                var response = await Api.DeleteIngredientAsync(ingredient.Id);
                if (response != null)
                {
                    _grid.Reload();
                }
            }
            catch (Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Error", "Unable to delete ingredient");
            }
        }

        protected void EditRowClick(IngredientModel ingredient)
        {
            _grid.EditRow(ingredient);
        }

        protected async Task SaveEditRowClick(IngredientModel ingredient)
        {
            await _grid.UpdateRow(ingredient);
            await Api.PatchIngredientAsync(ingredient);
        }

        protected void CancelEditRowClick(IngredientModel ingredient)
        {
            _grid.CancelEditRow(ingredient);
            _grid.Reload();
        }
    }
}
