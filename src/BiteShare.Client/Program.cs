using BiteShare.Client;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri(builder.Configuration["ApiBaseUrl"] ?? "https://localhost:5001")
});

// TODO: register a typed SignalR connection service here that wraps
// HubConnectionBuilder for OrderHub, with reconnect handling (see Stream A risk note).

await builder.Build().RunAsync();
