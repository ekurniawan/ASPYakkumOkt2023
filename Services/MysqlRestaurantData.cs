using System.Data.SqlTypes;
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
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Restaurants (Name) 
                                   values (@Name);select last_insert_id()";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", newT.Name);
                try
                {
                    conn.Open();
                    var newId = Convert.ToInt32(cmd.ExecuteScalar());
                    newT.Id = newId;
                    return newT;
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public Restaurant Delete(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Restaurants where Id=@Id";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result != 1)
                    {
                        throw new Exception("Data tidak ditemukan!");
                    }

                    return new Restaurant { Id = id };
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
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
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string strSql = @"update Restaurants set Name=@Name where Id=@Id";
                MySqlCommand cmd = new MySqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", updatedT.Name);
                cmd.Parameters.AddWithValue("@Id", updatedT.Id);
                try
                {
                    conn.Open();
                    int result = cmd.ExecuteNonQuery();
                    if (result != 1)
                    {
                        throw new Exception("Data tidak ditemukan!");
                    }

                    return updatedT;
                }
                catch (MySqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }
    }
}