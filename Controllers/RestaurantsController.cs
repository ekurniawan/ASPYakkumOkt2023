using Microsoft.AspNetCore.Mvc;
using MyASPWeb.Models;
using MyASPWeb.Services;
using MyASPWeb.ViewModels;


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

        public IActionResult RestaurantWithType()
        {
            List<RestaurantWithTypeVM> models = new List<RestaurantWithTypeVM>();
            var restaurants = _restaurantData.RestaurantWithType();
            foreach (var item in restaurants)
            {
                models.Add(new RestaurantWithTypeVM
                {
                    RestaurantId = item.Id,
                    RestaurantName = item.Name,
                    RestaurantTypeName = item.RestaurantType.TypeName
                });
            }
            return new JsonResult(models);
        }

        public IActionResult Index()
        {
            if (TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"];
            }

            //ViewModel
            var viewModel = new RestaurantViewModel();
            viewModel.Restaurants = _restaurantData.GetAll();
            viewModel.Username = "Erick Kurniawan";

            var models = _restaurantData.GetAll();
            ViewData["Username"] = "Erick Kurniawan";
            ViewBag.Resto = new Restaurant { Id = 11, Name = "Bakso Cakman" };
            //var model = new Restaurant { Id = 1, Name = "Bakso Bethesda" };
            return View(viewModel);
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
        public IActionResult Create(CreateRestaurantViewModel createResViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            //pindah dari viewmodel ke model
            var restaurant = new Restaurant()
            {
                Name = createResViewModel.Name
            };

            var newRestaurant = _restaurantData.Add(restaurant);
            TempData["Message"] = $"{newRestaurant.Name} has been added!";
            //return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            return RedirectToAction(nameof(Index));
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

        [HttpPost]
        public IActionResult DeletePost(int id)
        {
            var deletedRestaurant = _restaurantData.Delete(id);
            TempData["Message"] = $"{deletedRestaurant.Name} has been deleted!";
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}