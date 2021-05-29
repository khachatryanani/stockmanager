using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace WebApi.Models
{
    public class StockItemBaseModel
    {
        public int ProductId { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public string ProductionDate { get; set; }
        public string StockedDate { get; set; }
        public int CreatedById { get; set; }
    }
}