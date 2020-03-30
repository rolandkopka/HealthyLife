using HealthyLife.Models.Food;
using HealthyLife.Wasm.Services;
using Microsoft.AspNetCore.Components;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthyLife.Wasm.Pages
{
    public partial class AddIngredient
    {
        [Inject]
        private HealthyLifeOdataApiService Api { get; set; }
        [Inject]
        private DialogService DialogService { get; set; }
        [Inject]
        private NotificationService NotificationService { get; set; }

        private IngredientModel _ingredient;

        protected override void OnInitialized()
        {
            _ingredient = new IngredientModel();
        }

        private async Task FormSubmit()
        {
            try
            {
                await Api.CreateIngredientAsync(_ingredient);
                DialogService.Close(_ingredient);
            }
            catch (Exception)
            {
                NotificationService.Notify(NotificationSeverity.Error, "Error", "Unable to create new Ingredient!");
            }
        }
    }
}
