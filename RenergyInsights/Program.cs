using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RenergyInsights.Business.IServices;
using RenergyInsights.Business.Services;
using RenergyInsights.DAL.Data;
using RenergyInsights.DAL.Repositories;
using RenergyInsights.DAL.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IProducedEnergyInsights, ProducedEnergyInsights>();
builder.Services.AddScoped<IConsumerInsights, ConsumerInsights>();
builder.Services.AddScoped<IProducedEnergyRepository, ProducedEnergyRepository>();
builder.Services.AddScoped<IConsumerEnergyRepository, ConsumerEnergyRepository>();

//builder.Services.Configure<HomePartsConfig>(builder.Configuration.GetSection("HomeParts"));




// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();




var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

app.Run();
