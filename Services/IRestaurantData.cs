using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
    }
}