using System.ComponentModel.DataAnnotations;

namespace MyASPWeb.ViewModels
{
    public class CreateRestaurantViewModel
    {
        [Required(ErrorMessage = "Data Name harus diisi"), MaxLength(10)]
        public string? Name { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string Repassword { get; set; }
    }
}