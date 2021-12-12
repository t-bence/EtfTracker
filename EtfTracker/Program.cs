using Microsoft.EntityFrameworkCore;
using EtfTracker.Data;
using EtfTracker.Modules;
using EtfTracker.Modules.EtfPriceModule;
using EtfTracker.Modules.ExchangeRateModule;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appSecrets.json", optional: false);

// Add services to the container.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<EtfTrackerContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("EtfTrackerContext")));
builder.Services.AddScoped(typeof(Calculator));
builder.Services.AddScoped<IEtfPriceProvider, EtfPriceProvider>();
builder.Services.AddScoped<IExchangeRateProvider, ExchangeRateProvider>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
