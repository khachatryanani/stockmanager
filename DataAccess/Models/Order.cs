using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public string ReceivedBy { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string DeliveredBy { get; set; }
        public List<Product> ProductList { get; set; }
    }
}
