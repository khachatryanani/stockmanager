using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class InStockItemDetails
    {
        [ColumnName("ID")]
        public int ProductId { get; set; }

        [ColumnName("Name")]
        public string ProductName { get; set; }

        [ColumnName("Type")]
        public string ProductType { get; set; }

        [ColumnName("Quantity")]
        public int Quantity { get; set; }

        [ColumnName("Unit")]
        public string MeasurementUnit { get; set; }

        [ColumnName("Price")]
        public decimal Price { get; set; }

        [ColumnName("Produced On")]
        public DateTime ProductionDate { get; set; }

        [ColumnName("Stocked On")]
        public DateTime StockedDate { get; set; }

        [ColumnName("Expires On")]
        public DateTime ExpirationDate { get; set; }

        [ColumnName("Stocked By")]
        public string WorkerName { get; set; }

        [ColumnName("Employee ID")]
        public int WorkerId { get; set; }

    }
}
