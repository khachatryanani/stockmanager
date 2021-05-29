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
        private readonly DataRepService _dataRepository = new DataRepService(ConfigurationManager.ConnectionStrings["SmarterASP"].ConnectionString);
        public List<StockItemDTO> StockItems { get; set; }
        public ProductDTO StockedProduct { get; set; }
        public StockItemsViewModel()
        {
            StockedProduct = StockViewModel.SelectedProduct;
            if (StockedProduct != null) 
            {
                StockItems = _dataRepository.GetStockItems(StockedProduct.ProductId);
            }
        }

    }
}
