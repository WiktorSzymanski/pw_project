using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.DependencyInjection;
using Szymanska.LibraryApp.BlazorUI.Server.Services.BookService;
using Szymanski.LibraryApp.BL;
using Szymanski.LibraryApp.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddScoped<IBookService, BookService>();

//builder.Services.AddScoped<BL>()
//;
//builder.Services.AddSingleton<BL>();

//builder.Services.AddSingleton<BL>(provider =>
//{
//    return new BL("..\\..\\Szymanski.LibraryApp.DAOSQL\\bin\\Debug\\net7.0\\Szymanski.LibraryApp.DAOSQL.dll");
//});

//builder.Services.AddScoped(sp => new BL("Szymanski.LibraryApp.DAOSQL.dll"));

builder.Services.AddScoped(sp => new BL("bin/Debug/net7.0/Szymanski.LibraryApp.DAOSQL.dll"));


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
