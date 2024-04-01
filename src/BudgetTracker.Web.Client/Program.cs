global using BudgetTracker.Services.LocalHost.Interfaces;
using System.Net.Http;
using BudgetTracker.Services.LocalHost.Services;
using BudgetTracker.Web.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

var baseAddress = "https://localhost:7148/";
builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(baseAddress) } );

builder.Services.AddScoped<IApiService, ApiService>();

await builder.Build().RunAsync();
