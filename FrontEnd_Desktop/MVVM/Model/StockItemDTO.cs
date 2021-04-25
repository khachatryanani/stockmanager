using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class StockItemDTO
    {
        public ProductDTO StockedProduct { get; set; }

        public int Quantity { get; set; }
        
        public string ProductionDate { get; set; }

        public string StockedDate { get; set; }

        public string ExpirationDate { get; set; }

       public WorkerDTO Worker { get; set; }
    }
}
