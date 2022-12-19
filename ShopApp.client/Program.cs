using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ShopApp.client;
using ShopApp.client.ClientServices;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5138") });
builder.Services.AddScoped<IClientProductServices, ClientProductServices>();
builder.Services.AddScoped<IClientItemServices, ClientItemServices>();



await builder.Build().RunAsync();
