using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPWeb.ViewModels
{
    public class RestaurantWithTypeVM
    {
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantTypeName { get; set; }
    }
}