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
            throw new NotImplementedException();
        }

        public Customer Update(Customer updatedT)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}