using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class StockItemsViewModel: ObservableObject
    {
        private readonly DataRep _dataRepository = new DataRep(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);
        public List<StockItemDTO> StockItems { get; set; }
        public ProductDTO StockedProduct { get; set; }
        public StockItemsViewModel()
        {
            StockedProduct = StockViewModel.SelectedProduct;
            if (StockedProduct != null) 
            {
                StockItems = _dataRepository.GetStockItem(StockedProduct.ProductId);
            }
        }

    }
}
