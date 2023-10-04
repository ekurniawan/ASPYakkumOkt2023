using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyASPWeb.Models;

namespace MyASPWeb.Data
{
    public class RestaurantDbContext : IdentityDbContext //DbContext
    {
        public RestaurantDbContext(DbContextOptions options) : base(options)
        { }

        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<RestaurantMenu> RestaurantMenus { get; set; }
        public DbSet<RestaurantType> RestaurantTypes { get; set; }
    }
}