using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class OrderItem
    {
        [ColumnName("ID")]
        public int OrderId { get; set; }

        [ColumnName("Name")]
        public string ProductName { get; set; }

        [ColumnName("Unit")]
        public string MeasurementUnit { get; set; }

        [ColumnName("Quantity")]
        public int Quantity { get; set; }

        [ColumnName("Price")]
        public double Price { get; set; }

        [ColumnName("Status")]
        public string Status { get; set; }

    }
}
