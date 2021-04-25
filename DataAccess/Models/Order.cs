using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Order
    {
        public int OrderId { get; set; }
        public Customer Customer { get; set; }
        public double TotalPrice { get; set; }
        public DateTime ReceivedDate { get; set; }
        public Worker Receiver { get; set; }
        public string Status { get; set; }
        public DateTime DeliveryDate { get; set; }

        public Worker Deliverer { get; set; }

        public List<OrderItem> OrderItemList { get; set; }
    }
}
