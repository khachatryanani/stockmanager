using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class InStockItem
    {
        [ColumnName("ID")]
        public int ProductId { get; set; }

        [ColumnName("Name")]
        public string ProductName { get; set; }

        [ColumnName("Type")]
        public string ProductType { get; set; }

        [ColumnName("Total Quantity")]
        public int TotalQuantity { get; set; }

        [ColumnName("avg Unit Price")]
        public double AverageUnitPrice { get; set; }

        [ColumnName("Unit")]
        public string MeasurementUnit { get; set; }

    }
}
