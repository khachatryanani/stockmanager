﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OrderItem
    {
        public int OrderId { get; set; }
        public Product OrderedProduct { get; set; }
        public int Quantity { get; set; }
        public string OrderItemStatus { get; set; }
    }
}
