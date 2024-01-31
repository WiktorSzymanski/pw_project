using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Szymanska.LibraryApp.BlazorUI.Server.Services.BookService;
using Szymanska.LibraryApp.BlazorUI.Server.Services.AuthorService;
using Szymanska.LibraryApp.BlazorUI.Server.Services.PublisherService;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();

//builder.Services.AddScoped(sp => new BL("bin/Debug/net7.0/Szymanski.LibraryApp.DAOSQL.dll"));
//builder.Services.AddScoped(sp => new BL("../../Szymanski.LibraryApp.DAOSQL/bin/Debug/net7.0/Szymanski.LibraryApp.DAOSQL.dll"));
builder.Services.AddSingleton(sp => new BL("../../Szymanski.LibraryApp.DAOMock/bin/Debug/net7.0/Szymanski.LibraryApp.DAOMock.dll"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
