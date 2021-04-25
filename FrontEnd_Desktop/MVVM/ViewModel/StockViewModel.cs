using AutoMapper;
using DataAccess;
using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class StockViewModel : ObservableObject
    {
        private readonly DataRep _dataRepository = new DataRep(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);

        private object _rightSideView;
        private object _bottomSideView;

        public RelayCommand AddStockItemViewCommand { get; set; }
        public RelayCommand SubmitStockItemViewCommand { get; set; }
        public RelayCommand CloseStockItemViewCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand ViewStockItemsCommand { get; set; }
        public RelayCommand CloseStockItemsViewCommand { get; set; }


        public static ProductDTO SelectedProduct { get; set; }
        public  StockDTO SelectedStock { get; set; }
        public StockItemDTO StockItem { get; set; }


        public List<StockDTO> Stock { get; set; }
        public List<ProductDTO> ProductList { get; set; }
        public List<WorkerDTO> WorkerList { get; set; }


        public object RightSideView
        {
            get
            {
                return _rightSideView;
            }
            set
            {
                _rightSideView = value;
                OnPropertyChanged();
            }
        }

        public object BottomSideView
        {
            get
            {
                return _bottomSideView;
            }
            set
            {
                _bottomSideView = value;
                OnPropertyChanged();
            }
        }

        public StockViewModel()
        {
            Stock = _dataRepository.GetStockItems();
            WorkerList = _dataRepository.GetWorkers();
            ProductList = _dataRepository.GetProducts();

            StockItem = new StockItemDTO();

            AddStockItemViewCommand = new RelayCommand(o =>
            {
                RightSideView = new StockItemViewModel();
                BottomSideView = null;
            });

            SubmitStockItemViewCommand = new RelayCommand(o =>
            {
                StockItem.StockedDate = DateTime.Now.ToString();
                _dataRepository.CreateStockItem(StockItem);
                RightSideView = null;
            });

            SelectedItemChangedCommand = new RelayCommand(o =>
            {
                if (SelectedStock != null)
                {
                    SelectedProduct = SelectedStock.StockedProduct;
                }
            });

            CloseStockItemViewCommand = new RelayCommand(o =>
            {
                RightSideView = null;
            });

            CloseStockItemsViewCommand = new RelayCommand(o =>
            {
                BottomSideView = null;
            });

            ViewStockItemsCommand = new RelayCommand(o =>
            {
                if (SelectedProduct != null) 
                {
                    BottomSideView = new StockItemsViewModel();
                    RightSideView = null;
                }
            }); 
        }
    }
}
