using System;
using System.Collections.Generic;
using System.Text;
using FrontEnd_Desktop.Core;
using FrontEnd_Desktop.MVVM.Model;
using DataAccess;

namespace FrontEnd_Desktop.MVVM.ViewModel
{
    public class OrderViewModel: ObservableObject
    {

        //public static List<OrderDTO> GetOrders() 
        //{
        //    //var ordersList = MainViewModel.dataRepository.GetOrders();
        //    //var ordersModelList = new List<OrderDTO>();

        //    //foreach (var order in ordersList)
        //    //{
        //    //    ordersModelList.Add(new OrderDTO(order));
        //    //}

        //    //return ordersModelList;
        //}

        //public static List<ProductDTO> GetProducts()
        //{
        //    //var productList = MainViewModel.dataRepository.GetProducts();
        //    //var productModelList = new List<ProductDTO>();
        //    //foreach (var product in productList)
        //    //{
        //    //    productModelList.Add(new ProductDTO(product));
        //    //}

        //    //return productModelList;
        //}

        //public static List<WorkerDTO> GetWorkers()
        //{
        //    //var workerList = MainViewModel.dataRepository.GetWorkers();
        //    //var workerModelList = new List<WorkerDTO>();
        //    //foreach (var worker in workerList)
        //    //{
        //    //    workerModelList.Add(new WorkerDTO(worker));
        //    //}

        //    //return workerModelList;
        //}

        //public static List<CustomerDTO> GetCustomers() 
        //{
        //    var customerList = MainViewModel.dataRepository.GetCustomers();
        //    var customerModelList = new List<CustomerDTO>();
        //    foreach (var customer in customerList)
        //    {
        //        customerModelList.Add(new CustomerDTO(customer));
        //    }

        //    return customerModelList;
        //}

        //public static void CreateNewOrder(OrderDTO orderModel) 
        //{
        //    List<OrderItem> orderItems = new List<OrderItem>();
        //    foreach (var orderItemModel in orderModel.OrderItemList)
        //    {
        //        var orderItem = new OrderItem();

        //        orderItem.ProductId = orderItemModel.ProductId;
        //        orderItem.Quantity = orderItemModel.Quantity;

        //        orderItems.Add(orderItem);
        //    }

        //    var order = new Order();

        //    order.CustomerId = orderModel.CustomerId;
        //    order.ReceivedDate = DateTime.Parse(orderModel.ReceivedDate);
        //    order.ReceivedById = orderModel.ReceivedById;
        //    order.OrderItemList = orderItems;

        //    MainViewModel.dataRepository.CreateOrder(order);
        //}
    }
}
