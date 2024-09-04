using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

using MudBlazor.Services;

using WebApplication1;
using WebApplication1.Services.Ibge;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddCachedIbgeService();
builder.Services.AddMemoryCache(); // this is unnecessary, because it's already added by AddCachedIbgeService

builder.Services.AddMudServices();

await builder.Build().RunAsync();