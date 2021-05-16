using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class StockItemModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string UnitPrice { get; set; }
        public string Unit { get; set; }
        public string StockedDate { get; set; }
        public string ProductionDate { get; set; }
        public string ExpirationDate { get; set; }
        public int ActualQuantity { get; set; }
        public int CreatedById { get; set; }
        public string CreatedBy { get; set; }
    }
}
