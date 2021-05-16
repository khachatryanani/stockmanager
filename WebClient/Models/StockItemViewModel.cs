using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class StockItemViewModel
    {
        public int productId { get; set; }
        public string productName { get; set; }
        public string productType { get; set; }
        public string unitPrice { get; set; }
        public string unit { get; set; }
        public string stockedDate { get; set; }
        public string productionDate { get; set; }
        public string expirationDate { get; set; }
        public int actualQuantity { get; set; }
        public int createdById { get; set; }
        public string createdBy { get; set; }
    }
}
