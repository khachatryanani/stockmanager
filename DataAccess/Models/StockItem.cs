using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class StockItem
    {
        public int ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductType { get; set; }

        public int TotalQuantity { get; set; }

        public double AverageUnitPrice { get; set; }

        public string MeasurementUnit { get; set; }
    }
}
