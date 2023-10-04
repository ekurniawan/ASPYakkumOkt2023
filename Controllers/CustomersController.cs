using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyASPWeb.Services;
using MyASPWeb.ViewModels;

namespace MyASPWeb.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ILogger<CustomersController> _logger;
        private readonly ICustomer _customer;

        public CustomersController(ILogger<CustomersController> logger,
        ICustomer customer)
        {
            _logger = logger;
            _customer = customer;
        }

        public IActionResult Index()
        {
            var models = _customer.GetAll();
            return new JsonResult(models);
        }

        public IActionResult CustomerWithRestaurant()
        {
            List<CustomerWithRestaurantVM> models = new List<CustomerWithRestaurantVM>();
            var customers = _customer.GetAllWithRestaurant();
            foreach (var customer in customers)
            {
                models.Add(new CustomerWithRestaurantVM
                {
                    FirstName = customer.FirstName,
                    LastName = customer.LastName,
                    RestaurantName = customer.Restaurant.Name
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