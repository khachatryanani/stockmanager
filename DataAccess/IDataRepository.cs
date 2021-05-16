using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataRepository
    {
       
        List<Product> GetProducts();

        //Workers
        List<Worker> GetWorkers();
        Worker GetWorker(int id);
        void DeleteWorker(int id);
        void UpdateWorker(Worker worker);
        void CreateWorker(Worker worker);

        //Customers
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void CreateCustomer(Customer customer);
        void UpdateCustomer(Customer customer);

        //Stocks
        List<Stock> GetStocks();
        Stock GetStock(int stockId);
        List<StockItem> GetStockItems(int productId);
        StockItem GetStockItem(int itemId);
        void CreateStockItem(StockItem stockItem);

        //Orders
        List<Order> GetOrders();
        Order GetOrder(int orderId);
        void CreateOrder(Order order);
        List<Order> GetCustomerOrders(int customerId);
        List<OrderItem> GetOrderItems(int orderId);
        OrderItem GetOrderItem(int itemId);
        List<Order> GetDeliveryReadyOrders();
        List<Order> GetDeliveredOrders();
        void AcceptOrder(int orderId);
        void ApproveDelivery(int orderId, DateTime deliveryDate, int delivereId);
    }
}
