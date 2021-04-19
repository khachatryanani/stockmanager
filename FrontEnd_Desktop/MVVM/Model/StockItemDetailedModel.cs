using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class StockItemDetailedModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string MeasurementUnit { get; set; }


        public string ProductionDate { get; set; }

        public string StockedDate { get; set; }

        public string ExpirationDate { get; set; }

        public string WorkerName { get; set; }

        public int WorkerId { get; set; }

        public StockItemDetailedModel(StockItemDetailed stockItem)
        {
            this.ProductId = stockItem.ProductId;
            this.ProductName = stockItem.ProductName;
            this.Type = stockItem.ProductType;
            this.Quantity = stockItem.Quantity;
            this.UnitPrice = stockItem.AverageUnitPrice;
            this.MeasurementUnit = stockItem.MeasurementUnit;
            this.ProductionDate = stockItem.ProductionDate.ToShortDateString();
            this.StockedDate = stockItem.StockedDate.ToShortDateString();
            this.ExpirationDate = stockItem.ExpirationDate.ToShortDateString();
            this.WorkerName = stockItem.WorkerName;
            this.WorkerId = stockItem.WorkerId;
        }

        public StockItemDetailedModel()
        {

        }

    }
}
