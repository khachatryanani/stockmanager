using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string OrderItemStatus { get; set; }
    }
}
