using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyASPWeb.Data;
using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public class MysqlEFRestaurantMenu : IRestaurantMenu
    {
        private readonly RestaurantDbContext _db;
        public MysqlEFRestaurantMenu(RestaurantDbContext db)
        {
            _db = db;
        }
        public RestaurantMenu Add(RestaurantMenu newT)
        {
            throw new NotImplementedException();
        }

        public RestaurantMenu Delete(int id)
        {
            throw new NotImplementedException();
        }

        public RestaurantMenu Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RestaurantMenu> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<RestaurantMenu> GetWithRestaurantWithType()
        {
            var menus = _db.RestaurantMenus.Include(r => r.Restaurant)
                .ThenInclude(r => r.RestaurantType).OrderBy(r => r.MenuName);

            return menus;
        }

        public RestaurantMenu Update(RestaurantMenu updatedT)
        {
            throw new NotImplementedException();
        }
    }
}