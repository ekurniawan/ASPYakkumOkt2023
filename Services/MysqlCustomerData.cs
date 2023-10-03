using MyASPWeb.Models;
using MySql.Data.MySqlClient;

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

        IEnumerable<Customer> ICrud<Customer>.GetAll()
        {
            List<Customer> customers = new List<Customer>();
            using (MySqlConnection conn = new MySqlConnection(GetConnStr()))
            {
                conn.Open();
                string sql = @"select * from Customers order by FirstName asc";
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        customers.Add(new Customer
                        {
                            CustomerID = Convert.ToInt32(dr["CustomerID"]),
                            FirstName = (string)dr["FirstName"],
                            LastName = (string)dr["LastName"],
                            Address = (string)dr["Address"],
                            City = (string)dr["City"]
                        });
                    }
                }
            }
            return customers;
        }

        Customer ICrud<Customer>.Get(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Add(Customer newT)
        {
            throw new NotImplementedException();
        }

        public Customer Update(Customer updatedT)
        {
            throw new NotImplementedException();
        }

        Customer ICrud<Customer>.Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}