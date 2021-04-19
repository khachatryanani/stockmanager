using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class StockItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public string MeasurementUnit { get; set; }
        public StockItemModel(StockItem stockItemBase)
        {
            this.Id = stockItemBase.ProductId;
            this.Name = stockItemBase.ProductName;
            this.Type = stockItemBase.ProductType;
            this.Quantity = stockItemBase.TotalQuantity;
            this.UnitPrice = stockItemBase.AverageUnitPrice;
            this.MeasurementUnit = stockItemBase.MeasurementUnit;
        }

        public StockItemModel()
        {

        }
    }
}
