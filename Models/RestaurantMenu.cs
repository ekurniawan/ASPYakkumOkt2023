using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyASPWeb.Models
{
    public class RestaurantMenu
    {
        [Key]
        public int RestaurantMenuId { get; set; }

        [StringLength(255)]
        public string MenuName { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}