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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"insert into Restaurants (Name) 
                                   values (@Name);select scope_identity()";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", newT.Name);
                try
                {
                    conn.Open();
                    var newId = Convert.ToInt32(cmd.ExecuteScalar());
                    newT.Id = newId;
                    return newT;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public Restaurant Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"delete from Restaurants where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
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
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public Restaurant Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"select * from Restaurants where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Id", id);
                conn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Restaurant restaurant = new Restaurant
                    {
                        Id = Convert.ToInt32(dr["Id"]),
                        Name = dr["Name"].ToString()
                    };
                    return restaurant;
                }
                return null;
            }
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
            using (SqlConnection conn = new SqlConnection(GetConnStr()))
            {
                string strSql = @"update Restaurants set Name=@Name where Id=@Id";
                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@Name", updatedT.Name);
                cmd.Parameters.AddWithValue("@Id", updatedT.Id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    return updatedT;
                }
                catch (SqlException sqlEx)
                {
                    throw new Exception(sqlEx.Message);
                }
            }
        }

        public IEnumerable<Restaurant> RestaurantWithType()
        {
            throw new NotImplementedException();
        }
    }
}