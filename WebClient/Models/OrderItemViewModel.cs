using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class OrderItemViewModel
    {
        public int itemId { get; set; }
        public int orderId { get; set; }
        public string productName { get; set; }
        public string unitPrice { get; set; }
        public string unit { get; set; }
        public int quantity { get; set; }
        public string total { get; set; }
        public string orderItemStatus { get; set; }
    }
}