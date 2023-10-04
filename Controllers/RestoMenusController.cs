using Microsoft.AspNetCore.Mvc;
using MyASPWeb.Services;
using MyASPWeb.ViewModels;

namespace MyASPWeb.Controllers
{
    public class RestoMenusController : Controller
    {
        private readonly ILogger<RestoMenusController> _logger;
        private readonly IRestaurantMenu _restoMenu;

        public RestoMenusController(ILogger<RestoMenusController> logger,
        IRestaurantMenu restoMenu)
        {
            _logger = logger;
            _restoMenu = restoMenu;
        }

        public IActionResult Index()
        {
            List<MenuWithRestoWityTypeVM> models = new List<MenuWithRestoWityTypeVM>();
            var restoMenus = _restoMenu.GetWithRestaurantWithType();
            foreach (var restoMenu in restoMenus)
            {
                models.Add(new MenuWithRestoWityTypeVM
                {
                    RestaurantMenuId = restoMenu.RestaurantMenuId,
                    MenuName = restoMenu.MenuName,
                    RestaurantName = restoMenu.Restaurant.Name,
                    RestaurantTypeName = restoMenu.Restaurant.RestaurantType.TypeName
                });
            }

            return new JsonResult(models);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}