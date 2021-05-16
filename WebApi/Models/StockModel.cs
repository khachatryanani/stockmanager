using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace WebApi.Models
{
    public class StockModel
    {
        public int StockId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int TotalQuantity { get; set; }
        public string UnitPrice { get; set; }
        public string Unit { get; set; }
    }
}
