using HealthyLife.Data.Entities.Food;
using HealthyLife.Models;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace HealthyLife.API
{
    public static class EdmModelBuilder
    {
        private static IEdmModel _edmModel;

        public static IEdmModel GetEdmModel()
        {
            if (_edmModel == null)
            {
                var builder = new ODataConventionModelBuilder();
                builder.EntitySet<IngredientModel>("Ingredients");
                builder.EntitySet<Recipe>("Recipes");
                _edmModel = builder.GetEdmModel();
            }

            return _edmModel;
        }
    }
}
