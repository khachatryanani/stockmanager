using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class OrderItemDTO
    {
        public int OrderId { get; set; }
        public ProductDTO OrderedProduct { get; set; }
        public int Quantity { get; set; }
        public string OrderItemStatus { get; set; }
    }
}
