using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class OrderDTO
    {
        public int OrderId { get; set; }
        public CustomerDTO Customer { get; set; }

        public WorkerDTO ReceivedBy { get; set; }
        public string TotalPrice { get; set; }
        public string ReceivedDate { get; set; }
        public string Status { get; set; }
        public WorkerDTO DeliveredBy { get; set; }
        public string DeliveryDate { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }

        public OrderDTO()
        {
            OrderItems = new List<OrderItemDTO> { new OrderItemDTO()};

        }
    }
}
