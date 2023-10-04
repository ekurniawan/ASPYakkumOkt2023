using Microsoft.EntityFrameworkCore;
using MyASPWeb.Data;
using MyASPWeb.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//mendaftarkan penggunaan EF
builder.Services.AddDbContext<RestaurantDbContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("MysqlDbFirstConnection"));
});

//DI Dependency Injection
//builder.Services.AddSingleton<IRestaurantData, InMemoryRestaurantData>();

//builder.Services.AddScoped<IRestaurantData, MysqlRestaurantData>();
//builder.Services.AddScoped<IRestaurantData, SqlServerRestaurantData>();
builder.Services.AddScoped<IRestaurantData, MysqlEFRestaurantData>();

builder.Services.AddScoped<ICustomer, MysqlCustomerData>();

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

app.Run();
