using BookRateNetCore.Client.Services;
using BookRateNetCore.Server.Persistence;
using BookRateNetCore.Server.Seeders;
using BookRateNetCore.Shared.Services;
using Microsoft.AspNetCore.ResponseCompression;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddDbContext<BookDbContext>();
builder.Services.AddScoped<BookSeeder>();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IBookSeeder, BookSeeder>();

builder.Services.AddMediatR( cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly) );

var app = builder.Build();


var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<BookSeeder>();
await seeder.Seed();

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
app.MapFallbackToFile("index.html");

app.Run();
