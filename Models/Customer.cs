using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPWeb.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        //FK dari tabel Restaurant
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public Restaurant Restaurant { get; set; }
    }
}