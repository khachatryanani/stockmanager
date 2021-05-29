using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class OrderItemBaseViewModel
    {
        public int productId { get; set; }

        [Required]
        [Range(1, 10000)]
        public int quantity { get; set; }
    }
}
