using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyASPWeb.Data;
using MyASPWeb.Models;

namespace MyASPWeb.Services
{
    public class MysqlEFCustomerData : ICustomer
    {
        private readonly RestaurantDbContext _db;
        public MysqlEFCustomerData(RestaurantDbContext db)
        {
            _db = db;
        }

        public Customer Add(Customer newT)
        {
            throw new NotImplementedException();
        }

        public Customer Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Customer Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetAll()
        {
            var results = _db.Customers.OrderBy(r => r.FirstName);
            return results;
        }

        public IEnumerable<Customer> GetAllWithRestaurant()
        {
            var results = _db.Customers.Include(r => r.Restaurant).OrderBy(r => r.FirstName);
            return results;
        }

        public Customer Update(Customer updatedT)
        {
            throw new NotImplementedException();
        }
    }
}