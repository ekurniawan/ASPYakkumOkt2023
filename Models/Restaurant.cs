using System.ComponentModel.DataAnnotations;

namespace MyASPWeb.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
    }
}