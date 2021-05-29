using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataRepository
    {
        // Products
        void CreateProduct(Product product);
        List<Product> GetProducts();
        void UpdateProduct(Product product);
        void DeleteProduct(int id);

        //Workers
        void CreateWorker(Worker worker);
        List<Worker> GetWorkers();
        Worker GetWorker(int id);
        void UpdateWorker(Worker worker);
        void DeleteWorker(int id);

        //Customers
        void CreateCustomer(Customer customer);
        List<Customer> GetCustomers();
        Customer GetCustomer(int id);
        void UpdateCustomer(Customer customer);

        //Stocks
        void CreateStockItem(StockItem stockItem);
        List<Stock> GetStocks();
        List<StockItem> GetStockItems(int productId);
        StockItem GetStockItem(int itemId);
        List<StockItem> GetExpiredStockItems();

        //Orders
        void CreateOrder(Order order);
        List<Order> GetOrders(string status);
        Order GetOrder(int orderId);
        List<Order> GetCustomerOrders(int customerId);
        List<OrderItem> GetOrderItems(int orderId);
        OrderItem GetOrderItem(int itemId);
        void AcceptOrder(Order order);
        void ApproveDelivery(Order order);
        void UpdateOrder(Order order);
        void UpdateOrderItem(OrderItem orderItem);
        bool TryAcceptOrder(Order order);
        bool TryApproveDelivery(Order order);
    }
}
