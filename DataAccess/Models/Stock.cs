using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class Stock
    {
        public Product StockedProduct { get; set; }
        public int TotalQuantity { get; set; }
        public List<StockItem> StockItemList { get; set; }
    }
}
