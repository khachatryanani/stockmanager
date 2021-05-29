using System;
using System.Collections.Generic;
using System.Text;
using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;
using DataAccess;
using System.Configuration;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class OrdersViewModel: ObservableObject
    {
        private readonly DataRepService _dataRepository = new DataRepService(ConfigurationManager.ConnectionStrings["SmarterASP"].ConnectionString);

        private object _rightSideView;
        private object _bottomSideView;

       //commands
        public RelayCommand CreateOrderViewCommand { get; set; }
        public RelayCommand SubmitOrderViewCommand { get; set; }
        public RelayCommand ViewOrderItemsCommand { get; set; }
        public RelayCommand SelectedItemChangedCommand { get; set; }
        public RelayCommand AcceptOrderCommand { get; set; }
        public RelayCommand CloseOrderViewCommand { get; set; }
        public RelayCommand CloseOrderItemsViewCommand { get; set; }

        public static OrderDTO Order { get; set; }
        public List<OrderDTO> Orders { get; set; }
        public static OrderDTO SelectedOrder { get; set; }
        public List<ProductDTO> ProductList { get; set; }
        public List<WorkerDTO> WorkerList { get; set; }
        public List<CustomerDTO> CustomerList { get; set; }

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

        public OrdersViewModel()
        {
            Orders = _dataRepository.GetOrders();
            ProductList = _dataRepository.GetProducts();
            WorkerList = _dataRepository.GetWorkers();
            CustomerList = _dataRepository.GetCustomers();

            Order = new OrderDTO();
            CreateOrderViewCommand = new RelayCommand(o =>
            {
                RightSideView = new OrderViewModel();
                BottomSideView = null;
            });

            SubmitOrderViewCommand = new RelayCommand(o =>
            {
                _dataRepository.CreateOrder(Order);
                RightSideView = null;
            });

            CloseOrderViewCommand = new RelayCommand(o =>
            {
                RightSideView = null;
            });

            CloseOrderItemsViewCommand = new RelayCommand(o =>
            {
                BottomSideView = null;
            });

            //SelectedItemChangedCommand = new RelayCommand(o =>
            //{
            //    //if (SelectedStock != null)
            //    //{
            //    //    SelectedProduct = SelectedStock.StockedProduct;
            //    //}
            //});

            ViewOrderItemsCommand = new RelayCommand(o =>
            {
                if (SelectedOrder != null)
                {
                    BottomSideView = new OrderItemsViewModel();
                    RightSideView = null;
                }
            });
        }
    }
}
