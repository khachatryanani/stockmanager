using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class OrderItemsViewModel: ObservableObject
    {
        private readonly DataRepService _dataRepository = new DataRepService(ConfigurationManager.ConnectionStrings["SmarterASP"].ConnectionString);

        // commands
        public RelayCommand AcceptOrderCommand { get; set; }

        public List<OrderItemDTO> OrderItems { get; set; }
        public OrderDTO Order { get; set; }
        public ProductDTO StockedProduct { get; set; }
        public OrderItemsViewModel()
        {
            Order = OrdersViewModel.SelectedOrder;
            if (Order != null)
            {
                OrderItems = _dataRepository.GetOrderItems(Order.OrderId);
            }

            AcceptOrderCommand = new RelayCommand(o =>
            {
                Order.Status = "Accepted";
                _dataRepository.UpdateOrder(Order);
                OrderItems = _dataRepository.GetOrderItems(Order.OrderId);
            });
        }
    }
}
