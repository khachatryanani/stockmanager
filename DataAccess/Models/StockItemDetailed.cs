using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class StockItemDetailed: StockItem
    {
        public int Quantity { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime StockedDate { get; set; }

        public DateTime ExpirationDate { get; set; }

        public string WorkerName { get; set; }

        public int WorkerId { get; set; }
    }
}
