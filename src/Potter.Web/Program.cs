using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Potter.Application;
using Potter.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(typeof(CustomerProfile).Assembly);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<PotterDbContext>(c =>
    c.UseSqlServer(builder.Configuration.GetConnectionString("Local")));
builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
builder.Services.AddScoped<ICustomerService, CustomerService>();


var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();