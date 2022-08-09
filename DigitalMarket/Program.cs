using DigitalMarket.Data;
using DigitalMarket.Models.Repositories.Abstract;
using DigitalMarket.Models.Repositories.EntityFramework;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Service container
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DigitalMarketDbContext>(x => x.UseSqlServer(
    builder.Configuration.GetConnectionString("ProductsConnection")
    ));
builder.Services.AddTransient<IProductRepository, EFProductRepository>();

var app = builder.Build();

app.UseStaticFiles();

app.UseRouting();

// Routes
app.MapControllerRoute(
    name: "category",
    pattern: "{category}",
    defaults: new { controller = "Product", action = "List" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Product}/{action=List}/{id?}");

app.Run();
