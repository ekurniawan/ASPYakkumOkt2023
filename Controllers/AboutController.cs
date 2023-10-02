using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyASPWeb.Models;

namespace MyASPWeb.Controllers
{
    //[Route("yakkum/[controller]")]
    public class AboutController : Controller
    {
        private readonly ILogger<AboutController> _logger;

        public AboutController(ILogger<AboutController> logger)
        {
            _logger = logger;
        }

        //[Route("[action]")]
        public IActionResult Index()
        {
            return View();
        }

        //[Route("[action]")]
        public IActionResult Name()
        {
            _logger.LogInformation("Name() action invoked");
            var names = new List<string> { "Erick", "Rufus", "Iroen" };
            return new JsonResult(names);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}