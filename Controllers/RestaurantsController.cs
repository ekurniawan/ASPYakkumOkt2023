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
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            var models = _restaurantData.GetAll();
            ViewData["Username"] = "Erick Kurniawan";
            ViewBag.Resto = new Restaurant { Id = 11, Name = "Bakso Cakman" };
            //var model = new Restaurant { Id = 1, Name = "Bakso Bethesda" };
            return View(models);
        }

        public IActionResult Details(int id, string? name, string? address)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            ViewData["name"] = name;
            ViewBag.Address = address;
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Restaurant restaurant)
        {
            var newRestaurant = _restaurantData.Add(restaurant);
            return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            //return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult EditPost(Restaurant restaurant)
        {
            var updatedRestaurant = _restaurantData.Update(restaurant);
            //return RedirectToAction(nameof(Details), new { id = updatedRestaurant.Id });
            TempData["Message"] = "Data has been updated!";
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}