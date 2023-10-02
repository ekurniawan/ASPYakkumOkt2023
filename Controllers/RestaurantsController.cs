using Microsoft.AspNetCore.Mvc;
using MyASPWeb.Models;
using MyASPWeb.Services;


namespace MyASPWeb.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly ILogger<RestaurantsController> _logger;
        private readonly IRestaurantData _restaurantData;

        public RestaurantsController(ILogger<RestaurantsController> logger,
        IRestaurantData restaurantData)
        {
            _logger = logger;
            _restaurantData = restaurantData;
        }

        public IActionResult Index()
        {
            var models = _restaurantData.GetAll();
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