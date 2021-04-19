using DataAccess;
using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;
using System;
using System.Collections.Generic;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class InStockViewModel : ObservableObject
    {
        public static List<StockItemModel> GetStockItems() 
        {
            var stockItemList = MainViewModel.dataRepository.GetInStockItems();
            var stockItemModelList = new List<StockItemModel>();

            foreach (var item in stockItemList)
            {
                stockItemModelList.Add(new StockItemModel(item));
            }

            return stockItemModelList;
        }

        public static List<StockItemDetailedModel> GetStockItemDetails(int productId)
        {
            var stockItemDetails = MainViewModel.dataRepository.GetStockedProductDetails(productId);
            var stockItemModelDetails = new List<StockItemDetailedModel>();
            foreach (var item in stockItemDetails)
            {
                stockItemModelDetails.Add(new StockItemDetailedModel(item));
            }

            return stockItemModelDetails;
        }

        public static List<ProductModel> GetProducts()
        {
            var productList = MainViewModel.dataRepository.GetProducts();
            var productModelList = new List<ProductModel>();
            foreach (var product in productList)
            {
                productModelList.Add(new ProductModel(product));
            }

            return productModelList;
        }

        public static List<WorkerModel> GetWorkers()
        {
            var workerList = MainViewModel.dataRepository.GetWorkers();
            var workerModelList = new List<WorkerModel>();
            foreach (var worker in workerList)
            {
                workerModelList.Add(new WorkerModel(worker));
            }

            return workerModelList;
        }

        public static void AddNewItem(StockItemDetailedModel stockItemModel) 
        {
            StockItemDetailed stockItemDetailed = new StockItemDetailed
            {
                ProductId = stockItemModel.ProductId,
                ProductionDate = DateTime.Parse(stockItemModel.ProductionDate),
                StockedDate = DateTime.Now,
                Quantity = stockItemModel.Quantity,
                AverageUnitPrice = stockItemModel.UnitPrice,
                WorkerId = stockItemModel.WorkerId
            };

            MainViewModel.dataRepository.CreateNewStockItem(stockItemDetailed);
        }
    }
}
