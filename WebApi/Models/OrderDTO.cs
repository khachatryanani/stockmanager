using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public double TotalPrice { get; set; }
        public string ReceivedDate { get; set; }
        public int ReceiverId { get; set; }
        public string Receiver { get; set; }
        public string Status { get; set; }
        public string DeliveryDate { get; set; }
        public int DelivererId { get; set; }
        public string Deliverer { get; set; }
      
    }
}
