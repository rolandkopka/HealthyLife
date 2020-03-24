using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HealthyLife.Wasm.Services;
using Radzen;
using Serilog;

namespace HealthyLife.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.BrowserConsole().CreateLogger();

            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddBaseAddressHttpClient();
            builder.Services.AddScoped<HealthyLifeOdataApiService>();
            builder.Services.AddScoped<NotificationService>();

            await builder.Build().RunAsync();
        }
    }
}
