using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyASPWeb.Data;
using MyASPWeb.Models;
using ZstdSharp;

namespace MyASPWeb.Services
{
    public class MysqlEFRestaurantData : IRestaurantData
    {
        private readonly RestaurantDbContext _db;
        public MysqlEFRestaurantData(RestaurantDbContext db)
        {
            _db = db;
        }
        public Restaurant Add(Restaurant newT)
        {
            throw new NotImplementedException();
        }

        public Restaurant Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Restaurant Get(int id)
        {
            var result = _db.Restaurants.Find(id);
            /*var result = (from r in _db.Restaurants
                          where r.Id == id
                          select r).FirstOrDefault();*/
            if (result == null)
            {
                throw new Exception("Data tidak ditemukan");
            }
            return result;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            //var results = _db.Restaurants.OrderBy(r => r.Name);
            var results = from r in _db.Restaurants
                          orderby r.Name
                          select r;

            return results;
        }

        public IEnumerable<Restaurant> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public Restaurant Update(Restaurant updatedT)
        {
            throw new NotImplementedException();
        }
    }
}