using ForgingModelCalculator.Domain.Contracts;
using ForgingModelCalculator.Infrastructure.Calculators;
using ForgingModelCalculator.Web.Repositories;
using ForgingModelCalculator.Web.Services;
using ForgingModelCalculator.Web.Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IRolledRingToleranceAllowanceRepository, ExcelDataRepository>();
builder.Services.AddScoped<IRolledRingForgeSizesCalculator, RolledRingForgingSizesCalculator>();
builder.Services.AddScoped<IRolledRingForgingMassesCalculator, RolledRingForgingMassesCalculator>();
builder.Services.AddScoped<IRolledRingServices, RolledRingServices>();
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
    pattern: "{controller=RolledRing}/{action=Index}/{id?}");

app.Run();