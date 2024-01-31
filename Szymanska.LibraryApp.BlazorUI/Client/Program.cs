using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Szymanska.LibraryApp.BlazorUI.Client;
using Szymanska.LibraryApp.BlazorUI.Client.Services.BookService;
using Szymanska.LibraryApp.BlazorUI.Client.Services.AuthorService;
using Szymanska.LibraryApp.BlazorUI.Client.Services.PublisherService;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

await builder.Build().RunAsync();