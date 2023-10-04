using System.ComponentModel.DataAnnotations;

namespace MyASPWeb.Models
{
    public class RestaurantType
    {
        [Key]
        public int RestaurantTypeId { get; set; }

        [StringLength(255)]
        public string TypeName { get; set; }

        public IEnumerable<Restaurant> Restaurants { get; set; }

    }
}