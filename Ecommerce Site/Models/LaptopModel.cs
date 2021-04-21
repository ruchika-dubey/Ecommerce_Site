using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Ecommerce_Site.Models
{
    public class LaptopModel
    {
        
        public int ID { get; set; }
        [Required]
        public string ProductName { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
    }
}
