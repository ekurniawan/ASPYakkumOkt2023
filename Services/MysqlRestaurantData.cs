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

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
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
            Restaurant restaurant = new Restaurant();
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                conn.Open();
                string sql = @"select * from Restaurants where Id=@Id";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    restaurant = new Restaurant
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = (string)dr["Name"],
                    };
                }
            }
            return restaurant;
        }

        public IEnumerable<Restaurant> GetAll()
        {
            List<Restaurant> restaurants = new List<Restaurant>();
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                conn.Open();
                string sql = @"select * from Restaurants order by Name asc";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        restaurants.Add(new Restaurant
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = (string)dr["Name"],
                        });
                    }
                }
            }
            return restaurants;
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