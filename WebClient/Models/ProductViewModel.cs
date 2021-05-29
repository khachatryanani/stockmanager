using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class ProductViewModel
    {
        public int productId { get; set; }

        [Required]
        public string name { get; set; }

        [Required]
        public char category { get; set; }

        public string type { get; set; }

        [Required]
        public int typeId { get; set; }

        public string unit { get; set; }

        [Required]
        public int unitId { get; set; }

        public double price { get; set; }
    }
}
