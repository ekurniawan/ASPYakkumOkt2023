using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyASPWeb.Services;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}