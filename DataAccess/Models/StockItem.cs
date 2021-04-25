using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class StockItem
    {
        public Product StockedProduct { get; set; }
        public int Quantity { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime StockedDate { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Worker Worker { get; set; }
    }
}
