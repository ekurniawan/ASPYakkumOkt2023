using System.ComponentModel.DataAnnotations;

namespace MyASPWeb.Models
{
    public class Restaurant
    {
        public int Id { get; set; }

        [StringLength(255)]
        public string? Name { get; set; }

        public RestaurantType RestaurantType { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        public IEnumerable<RestaurantMenu> RestaurantMenus { get; set; }

    }
}