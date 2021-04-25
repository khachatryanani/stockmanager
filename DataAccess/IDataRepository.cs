using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess
{
    public interface IDataRepository
    {
        List<Stock> GetStockItems();

        List<Product> GetProducts();

        List<Worker> GetWorkers();

        List<Customer> GetCustomers();

        List<StockItem> GetStockItem(int productId);

        List<Order> GetOrders();

        List<OrderItem> GetOrder(int orderId);

        List<Order> GetDeliveryReadyOrders();

        List<Order> GetDeliveredOrders();

        void CreateOrder(Order order);

        void CreateStockItem(StockItem stockItem);

        void AcceptOrder(int orderId);

        void ApproveDelivery(int orderId, DateTime deliveryDate, int delivereId);
    }
}
