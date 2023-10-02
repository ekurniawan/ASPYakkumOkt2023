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

        public Restaurant Add(Restaurant newRestaurant)
        {
            _restaurants.Add(newRestaurant);
            newRestaurant.Id = _restaurants.Max(r => r.Id) + 1;
            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            /*var restaurant  = (from r in _restaurants
                              where r.Id == id
                              select r).FirstOrDefault();*/
            var restaurant = _restaurants.FirstOrDefault(r => r.Id == id);
            if (restaurant == null)
            {
                throw new Exception("Restaurant not found!");
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            /*var restaurants = from r in _restaurants
                              orderby r.Name
                              select r;*/
            return _restaurants.OrderBy(r => r.Name);
        }
    }
}