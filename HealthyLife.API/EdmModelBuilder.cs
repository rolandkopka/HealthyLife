using HealthyLife.Domain.Food;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace HealthyLife.Data
{
    public static class EdmModelBuilder
    {
        private static IEdmModel _edmModel;

        public static IEdmModel GetEdmModel()
        {
            if (_edmModel == null)
            {
                var builder = new ODataConventionModelBuilder();
                builder.EntitySet<Ingredient>("Ingredients");
                builder.EntitySet<Recipe>("Recipes");
                _edmModel = builder.GetEdmModel();
            }

            return _edmModel;
        }
    }
}
