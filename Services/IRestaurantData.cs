using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public interface IRestaurantData : ICrud<Restaurant>
    {
        IEnumerable<Restaurant> GetByName(string name);
    }
}