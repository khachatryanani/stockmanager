using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public class NewStockItem
    {
        public int ProductId { get; set; }
        public DateTime ProductionDate { get; set; }
        public DateTime StockedDate { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public int WorkerId { get; set; }

    }
}
