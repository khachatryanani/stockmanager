using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Models
{
    public class OrderViewModel
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
        public string customerName { get; set; }
        public string totalPrice { get; set; }
        public string receiver { get; set; }
        public int receiverId { get; set; }
        public string receivedDate { get; set; }
        public string status { get; set; }
        public string deliveryDate { get; set; }
        public int delivererId { get; set; }
        public string deliverer { get; set; }
    }
}
