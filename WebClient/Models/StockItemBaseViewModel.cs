using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class StockItemBaseViewModel
    {
        public int productId { get; set; }

        [Required]
        [Range(1.0,10000.0)]
        public double unitPrice { get; set; }

        [Required]
        public string stockedDate { get; set; }

        [Required]
        public string productionDate { get; set; }

        [Required]
        [Range(1, 10000)]
        public int quantity { get; set; }

        [Required]
        public int createdById { get; set; }
    }
}
