using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using HealthyLife.Wasm.Services;
using Radzen;
using Serilog;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;

namespace HealthyLife.Wasm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration().WriteTo.BrowserConsole().CreateLogger();


            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.Services
                .AddBlazorise(options => { options.ChangeTextOnKeyPress = true; })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            builder.Services.AddBaseAddressHttpClient();

            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped<HealthyLifeOdataApiService>();

            builder.Services.AddScoped<DialogService>();
            builder.Services.AddScoped<NotificationService>();


            var host = builder.Build();

            host.Services
                .UseBootstrapProviders()
                .UseFontAwesomeIcons();

            await host.RunAsync();
        }
    }
}
