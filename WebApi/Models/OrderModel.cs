using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string TotalPrice { get; set; }
        public string Receiver { get; set; }
        public int ReceiverId { get; set; }
        public string ReceivedDate { get; set; }
        public string Status { get; set; }
        public string DeliveryDate { get; set; }
        public int DelivererId { get; set; }
        public string Deliverer { get; set; }
    }
}
