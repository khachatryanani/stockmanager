using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public string CustomerName { get; set; }
        public int CustomerId { get; set; }
        public string TotalPrice { get; set; }
        public string ReceivedDate { get; set; }
        public string Receiver { get; set; }
        public int ReceiverId { get; set; }
        public string Status { get; set; }
        public string DeliveryDate { get; set; }
        public string Deliverer { get; set; }
        public int DelivererId { get; set; }
    }
}
