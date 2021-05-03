using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.Model
{
    public class StockDTO
    {
        public ProductDTO StockedProduct { get; set; }
        public int TotalQuantity { get; set; }
        public List<StockItemDTO> StockItemList { get; set; }
        public StockDTO()
        {
            StockItemList = new List<StockItemDTO>();
        }
    }
}
