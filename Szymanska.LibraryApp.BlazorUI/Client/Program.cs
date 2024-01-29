using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Szymanska.LibraryApp.BlazorUI.Client;
using Szymanska.LibraryApp.BlazorUI.Client.Services.BookService;
using Szymanski.LibraryApp.BL;
using Microsoft.Extensions.DependencyInjection;

using System;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IBookService, BookService>();

await builder.Build().RunAsync();