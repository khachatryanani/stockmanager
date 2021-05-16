using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class StockViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public int totalQuantity { get; set; }
        public string unitPrice { get; set; }
        public string unit { get; set; }
    }
}
