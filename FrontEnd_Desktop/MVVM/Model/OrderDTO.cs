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
        public double TotalPrice { get; set; }
        public string ReceivedDate { get; set; }
        public WorkerDTO Receiver { get; set; }
        public string Status { get; set; }
        public string DeliveryDate { get; set; }

        public WorkerDTO Deliverer { get; set; }
        public List<OrderItemDTO> OrderItemList { get; set; }

        public OrderDTO()
        {
            OrderItemList = new List<OrderItemDTO>();
        }

    }
}
