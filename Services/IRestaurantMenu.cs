using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public interface IRestaurantMenu : ICrud<RestaurantMenu>
    {
        IEnumerable<RestaurantMenu> GetWithRestaurantWithType();
    }
}