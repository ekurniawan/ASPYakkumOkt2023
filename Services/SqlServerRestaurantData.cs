using Microsoft.Data.SqlClient;
using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public class SqlServerRestaurantData : IRestaurantData
    {

        private readonly IConfiguration _config;
        public SqlServerRestaurantData(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("SqlServerConnection");
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
            throw new NotImplementedException();
        }

        public IEnumerable<Restaurant> GetAll()
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurants";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                List<Restaurant> lstRestaurant = new List<Restaurant>();
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lstRestaurant.Add(new Restaurant
                        {
                            Id = Convert.ToInt32(dr["Id"]),
                            Name = dr["Name"].ToString()
                        });
                    }
                }
                dr.Close();
                return lstRestaurant;
            }
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