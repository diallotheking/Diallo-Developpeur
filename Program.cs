using AppMarketingAlimentaire.Data;
using AppMarketingAlimentaire.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//Register services here add by me
builder.Services.AddDbContext<MarketingDbContext>(options => options.UseSqlServer(
builder.Configuration.GetConnectionString("MarketingConnection")));

//Service configuration add by me 29-11-2022
builder.Services.AddScoped<MarketingDbContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
//after make seed add this
MarketingDbInitializer.Seed(app);
app.Run();
