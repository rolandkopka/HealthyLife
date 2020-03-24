using HealthyLife.Domain.Food;
using Radzen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthyLife.Wasm.Services
{
    public class HealthyLifeOdataApiService
    {
        private readonly HttpClient _httpClient;
        private readonly Uri _baseUri;

        public HealthyLifeOdataApiService()
        {
            _httpClient = new HttpClient();
            _baseUri = new Uri("https://localhost:5001/odata/");
        }

        public async Task<ODataServiceResult<Ingredient>> GetIngredientsAsync(
            string filter = default, int? top = default, int? skip = default, string orderby = default,
            string expand = default, string select = default, bool? count = default)
        {
            var uri = new Uri(_baseUri, "Ingredients");
            uri = uri.GetODataUri(filter, top, skip, orderby, expand, select, count);
            var response = await _httpClient.GetAsync(uri);
            return await response.ReadAsync<ODataServiceResult<Ingredient>>();
        }
    }
}
