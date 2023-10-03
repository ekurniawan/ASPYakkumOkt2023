using System.ComponentModel.DataAnnotations;

namespace MyASPWeb.ViewModels
{
    public class CreateRestaurantViewModel
    {
        [Required]
        public string? Name { get; set; }
    }
}