using MyASPWeb.Models;
using MySql.Data.MySqlClient;
using Dapper;

namespace MyASPWeb.Services
{
    public class MysqlCustomerData : ICustomer
    {
        private readonly IConfiguration _config;
        public MysqlCustomerData(IConfiguration config)
        {
            _config = config;
        }

        private string GetConnStr()
        {
            return _config.GetConnectionString("DefaultConnection");
        }

        public IEnumerable<Customer> GetAll()
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                conn.Open();
                string sql = @"select * from Customers order by FirstName asc";
                var customers = conn.Query<Customer>(sql);
                return customers;
            }
        }

        public Customer Get(int id)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                conn.Open();
                string sql = @"select * from Customers where Id=@Id";
                var param = new { Id = id };
                var customer = conn.QueryFirstOrDefault<Customer>(sql, param);
                if (customer == null)
                {
                    throw new Exception("Data tidak ditemukan!");
                }
                return customer;
            }
        }

        public Customer Add(Customer newT)
        {
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                string sql = @"insert into Customers (FirstName, LastName, Address, City) 
                                values (@FirstName, @LastName, @Address, @City)";
                var param = new
                {
                    FirstName = newT.FirstName,
                    LastName = newT.LastName,
                    City = newT.City,
                    Address = newT.Address
                };
                var result = conn.Execute(sql, param);
                if (result == 0)
                {
                    throw new Exception("Data gagal ditambahkan!");
                }
                return newT;
            }
        }

        public Customer Update(Customer updatedT)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAllWithRestaurant()
        {
            throw new NotImplementedException();
        }
    }
}