using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPWeb.Models;

namespace MyASPWeb.ViewModels
{
    public class RestaurantViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string Username { get; set; }
    }
}