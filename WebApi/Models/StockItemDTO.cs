using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class StockItemDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public double UnitPrice { get; set; }
        public string Unit { get; set; }
        public int Quantity { get; set; }
        public string ProductionDate { get; set; }
        public string StockedDate { get; set; }
        public string ExpirationDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedById { get; set; }

    }
}
