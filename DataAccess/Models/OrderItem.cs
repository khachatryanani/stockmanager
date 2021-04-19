using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OrderItem: Order
    {
        public string ProductName { get; set; }

        public string MeasurementUnit { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public string ItemStatus { get; set; }
    }
}
