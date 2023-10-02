using Microsoft.AspNetCore.Mvc;
using MyASPWeb.Models;


namespace MyASPWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ILogger<RestaurantsController> _logger;
        public RestaurantsController(ILogger<RestaurantsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var models = new List<Restaurant>
            {
                new Restaurant { Id = 1, Name = "Bakso Bethesda" },
                new Restaurant { Id = 2, Name = "Sate Pak Bari" },
                new Restaurant { Id = 3, Name = "Soto Pak Soleh" }
            };
            ViewData["Username"] = "Erick Kurniawan";
            ViewBag.Resto = new Restaurant { Id = 11, Name = "Bakso Cakman" };
            //var model = new Restaurant { Id = 1, Name = "Bakso Bethesda" };
            return View(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}