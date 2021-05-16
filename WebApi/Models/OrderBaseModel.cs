using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class OrderBaseModel
    {
        public int CustomerId { get; set; }
        public string ReceivedDate { get; set; }
        public int ReceiverId { get; set; }
        public List<OrderItemBaseModel> OrderItems { get; set; } 
    }
}
