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
        private readonly DataRep _dataRepository = new DataRep(ConfigurationManager.ConnectionStrings["SQLServer"].ConnectionString);

        private object _rightSideView;
        private object _bottomSideView;

        public static OrderDTO Order { get; set; }
        public RelayCommand CreateOrderViewCommand { get; set; }


        public List<OrderDTO> Orders { get; set; }
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
        }
    }
}
