using MyASPWeb.Models;
using MySql.Data.MySqlClient;

namespace MyASPWeb.Services
{
    public class MysqlRestaurantData : IRestaurantData
    {
        private readonly IConfiguration _config;
        public MysqlRestaurantData(IConfiguration config)
        {
            _config = config;
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
            using (MySqlConnection conn = new MySqlConnection())
            {

            }
        }

        public IEnumerable<Restaurant> GetAll()
        {
            throw new NotImplementedException();
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