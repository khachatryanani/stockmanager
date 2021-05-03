using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace WebApi.Models
{
    public class StockDTO
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public int TotalQuantity { get; set; }
        public double UnitPrice { get; set; }
        public string Unit { get; set; }
    }
}
