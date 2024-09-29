using BookRateNetCore.Client.Services;
using BookRateNetCore.Server.Hubs;
using BookRateNetCore.Server.Persistence;
using BookRateNetCore.Server.Seeders;
using BookRateNetCore.Server.Services;
using BookRateNetCore.Shared.Services;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Hosting;
using System.Net.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSignalR();

builder.Services.AddSingleton<MqttService>();
builder.Services.AddDbContext<BookDbContext>();
builder.Services.AddScoped<BookSeeder>();

//builder.Services.AddScoped<IBookService, BookService>();                  // not used, replaced by MediatR

builder.Services.AddScoped<IBookSeeder, BookSeeder>();
builder.Services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly) );

//builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });


var app = builder.Build();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<BookSeeder>();
await seeder.SeedBook();
await seeder.SeedCategory();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
}



app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();

app.MapHub<TeamRetroHub>("/teamRetroHub");

app.MapFallbackToFile("index.html");

app.Run();
