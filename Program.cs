using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NobelPrizeApp.Services;
using NobelPrizeApp; // Add this line to include the namespace for the App component
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace NobelPrizeApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddScoped<NobelPrizeService>();

            await builder.Build().RunAsync();
        }
    }
}