using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class OrderItemModel: OrderItemBaseModel
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string UnitPrice { get; set; }
        public string Unit { get; set; }
        public string OrderItemStatus { get; set; }
    }
}
