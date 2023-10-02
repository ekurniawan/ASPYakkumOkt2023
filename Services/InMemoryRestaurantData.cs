using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>(){
                new Restaurant { Id = 1, Name = "Bakso Bethesda" },
                new Restaurant { Id = 2, Name = "Sate Pak Bari" },
                new Restaurant { Id = 3, Name = "Soto Pak Soleh" }
            };
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}