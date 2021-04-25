using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class DataRepository : IDataRepository
    {
        //For ComboBox dropdowns
        private List<Product> products;
        private List<Worker> workers;
        private List<Customer> customers;

        private readonly string connectionString;

        public DataRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Stock> GetStockItems()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetInStockItems]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var stock = new List<Stock>();
                        if (reader.HasRows)
                        {
                            int ordProductId = reader.GetOrdinal("ProductId");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordProductType = reader.GetOrdinal("ProductType");
                            int ordTotal = reader.GetOrdinal("Total");
                            int ordPrice = reader.GetOrdinal("AverageUnitPrice");
                            int ordMeasurement = reader.GetOrdinal("MeasurementUnit");

                            while (reader.Read())
                            {
                                var stockedProduct = new Product
                                {
                                    ProductId = reader.GetInt32(ordProductId),
                                    Name = reader.GetString(ordProductName),
                                    Type = reader.GetString(ordProductType),
                                    Price = Convert.ToDouble(reader.GetDecimal(ordPrice)),
                                    Unit = reader.GetString(ordMeasurement)
                                };

                                stock.Add(
                                    new Stock
                                    {
                                        TotalQuantity = reader.GetInt32(ordTotal),
                                        StockedProduct = stockedProduct
                                    });
                            }
                        }
                        return stock;
                    }
                }
            }
        }

        public List<Product> GetProducts()
        {
            if (this.products != null)
            {
                return this.products;
            }

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetProducts]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var productList = new List<Product>();
                        if (reader.HasRows)
                        {
                            int ordProductId = reader.GetOrdinal("ProductId");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordMeasurement = reader.GetOrdinal("MeasurementUnit");

                            while (reader.Read())
                            {
                                productList.Add(
                                    new Product
                                    {
                                        ProductId = reader.GetInt32(ordProductId),
                                        Name = reader.GetString(ordProductName),
                                        Unit = reader.GetString(ordMeasurement)
                                    });
                            }
                        }
                        this.products = productList;

                        return productList;
                    }
                }
            }
        }

        public List<Worker> GetWorkers()
        {
            if (this.workers != null)
            {
                return this.workers;
            }

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetWorkers]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var workerList = new List<Worker>();
                        if (reader.HasRows)
                        {
                            int ordWorkerId = reader.GetOrdinal("WorkerId");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordEmail = reader.GetOrdinal("Email");

                            while (reader.Read())
                            {
                                workerList.Add(
                                    new Worker
                                    {
                                        WorkerId = reader.GetInt32(ordWorkerId),
                                        Name = reader.GetString(ordFirstName),
                                        Surname = reader.GetString(ordLastName),
                                        Email = reader.GetString(ordEmail)
                                    });
                            }
                        }
                        this.workers = workerList;

                        return workerList;
                    }
                }
            }
        }

        public List<Customer> GetCustomers()
        {
            if (this.customers != null)
            {
                return this.customers;
            }

            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetCustomers]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var customerList = new List<Customer>();
                        if (reader.HasRows)
                        {
                            int ordCustomerId = reader.GetOrdinal("CustomerId");
                            int ordCustomertName = reader.GetOrdinal("CustomerName");
                            int ordCustomerAddress = reader.GetOrdinal("CustomerAddress");
                            int ordPhoneNumber = reader.GetOrdinal("PhoneNumber");

                            while (reader.Read())
                            {
                                customerList.Add(
                                    new Customer
                                    {
                                        CustomerId = reader.GetInt32(ordCustomerId),
                                        Name = reader.GetString(ordCustomertName),
                                        Address = reader.GetString(ordCustomerAddress),
                                        Phone = reader.GetString(ordPhoneNumber)
                                    });
                            }
                        }

                        this.customers = customerList;
                        return customerList;
                    }
                }
            }
        }

        public List<StockItem> GetStockItem(int productId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStockedProductDetails]";
                    command.Parameters.Add("@productId", SqlDbType.Int).Value = productId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var stockItem = new List<StockItem>();
                        if (reader.HasRows)
                        {
                            int ordProductId = reader.GetOrdinal("Productid");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordProductType = reader.GetOrdinal("ProductType");
                            int ordPrice = reader.GetOrdinal("UnitPrice");
                            int ordMUnit = reader.GetOrdinal("MeasurementUnit");
                            int ordStockedDate = reader.GetOrdinal("StockedDate");
                            int ordProductionDate = reader.GetOrdinal("ProductionDate");
                            int ordExpirationDate = reader.GetOrdinal("ExpirationDate");
                            int ordQuantity = reader.GetOrdinal("ActualQuantity");
                            int ordWorker = reader.GetOrdinal("CreatedBy");
                            int ordWorkerId = reader.GetOrdinal("WorkerId");

                            while (reader.Read())
                            {
                                var stockedProduct = new Product
                                {
                                    ProductId = reader.GetInt32(ordProductId),
                                    Name = reader.GetString(ordProductName),
                                    Type = reader.GetString(ordProductType),
                                    Price = Convert.ToDouble(reader.GetDecimal(ordPrice)),
                                    Unit = reader.GetString(ordMUnit)
                                };

                                var worker = new Worker
                                {
                                    Name = reader.GetString(ordWorker),
                                    WorkerId = reader.GetInt32(ordWorkerId)
                                };

                                stockItem.Add(
                                    new StockItem
                                    {
                                        StockedProduct = stockedProduct,
                                        StockedDate = reader.GetDateTime(ordStockedDate),
                                        ProductionDate = reader.GetDateTime(ordProductionDate),
                                        ExpirationDate = reader.GetDateTime(ordExpirationDate),
                                        Quantity = reader.GetInt32(ordQuantity),
                                        Worker = worker
                                    }) ;
                            }
                        }

                        return stockItem;
                    }
                }
            }
        }

        public List<Order> GetOrders()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetOrders]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var orders = new List<Order>();
                        if (reader.HasRows)
                        {
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordCustomerName = reader.GetOrdinal("CustomerName");
                            int ordCustomerAddress = reader.GetOrdinal("CustomerAddress");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordReceivedDate = reader.GetOrdinal("ReceivedDate");
                            int ordReceivedBy = reader.GetOrdinal("ReceivedBy");
                            int ordDeliveryDate = reader.GetOrdinal("DeliveredDate");
                            int ordDeliveredBy = reader.GetOrdinal("DeliveredBy");
                            int ordStatus = reader.GetOrdinal("Status");

                            while (reader.Read())
                            {
                                var customer = new Customer
                                {
                                    Name = reader.GetString(ordCustomerName),
                                    Address = reader.GetString(ordCustomerAddress),
                                };

                                var receiver = new Worker
                                {
                                    Name = reader.GetString(ordReceivedBy),
                                };

                                var deliverer = new Worker
                                {
                                    Name = reader.IsDBNull(ordDeliveredBy) ? default : reader.GetString(ordDeliveredBy),
                                };

                                orders.Add(
                                    new Order
                                    {
                                        OrderId = reader.GetInt32(ordOrderId),
                                        Customer = customer,
                                        TotalPrice = Convert.ToDouble(reader.GetDecimal(ordTotalPrice)),
                                        ReceivedDate = reader.GetDateTime(ordReceivedDate),
                                        Receiver = receiver,
                                        DeliveryDate = reader.IsDBNull(ordDeliveryDate) ? default : reader.GetDateTime(ordDeliveryDate),
                                        Deliverer = deliverer,
                                        Status = reader.GetString(ordStatus)
                                    }); 
                            }
                        }

                        return orders;
                    }
                }
            }
        }

        public List<OrderItem> GetOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetOrderDetails]";
                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var orderItems = new List<OrderItem>();
                        if (reader.HasRows)
                        {
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordUnit = reader.GetOrdinal("MeasurementUnit");
                            int ordQuantity = reader.GetOrdinal("Quantity");
                            int ordUnitPrice = reader.GetOrdinal("Price");
                            int ordStatus = reader.GetOrdinal("Status");

                            while (reader.Read())
                            {
                                var orderedProduct = new Product
                                {
                                    Name = reader.GetString(ordProductName),
                                    Unit = reader.GetString(ordUnit),
                                    Price = Convert.ToDouble(reader.GetDecimal(ordUnitPrice))
                                };

                                orderItems.Add(
                                    new OrderItem
                                    {
                                        OrderId = reader.GetInt32(ordOrderId),
                                        OrderedProduct = orderedProduct,
                                        Quantity = reader.GetInt32(ordQuantity),
                                        OrderItemStatus = reader.GetString(ordStatus)
                                    });
                            }
                        }

                        return orderItems;
                    }
                }
            }
        }

        public List<Order> GetDeliveryReadyOrders()
        {
            var orders = GetOrders();
            return orders.Where(s => s.Status == "Accepted").ToList();
        }

        public List<Order> GetDeliveredOrders()
        {
            var orders = GetOrders();
            return orders.Where(s => s.Status == "Delivered").ToList();
        }

        public void CreateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateNewOrder]";

                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = order.Customer.CustomerId;
                    command.Parameters.Add("@recievedDate", SqlDbType.DateTime2).Value = order.ReceivedDate;
                    command.Parameters.Add("@receiverId", SqlDbType.Int).Value = order.Receiver.WorkerId;
                    command.Parameters.Add("@productList", SqlDbType.Structured).Value = order.OrderItemList.ConvertToProductsDataTable();

                    command.ExecuteNonQuery();
                }
            }
        }

        public void CreateStockItem(StockItem stockItem)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[InStockNewItem]";

                    command.Parameters.Add("@productId", SqlDbType.Int).Value = stockItem.StockedProduct.ProductId;
                    command.Parameters.Add("@productionDate", SqlDbType.DateTime2).Value = stockItem.ProductionDate;
                    command.Parameters.Add("@stockedDate", SqlDbType.DateTime2).Value = stockItem.StockedDate;
                    command.Parameters.Add("@producedQuantity", SqlDbType.Int).Value = stockItem.Quantity;
                    command.Parameters.Add("@unitPrice", SqlDbType.Decimal).Value = Convert.ToDecimal(stockItem.StockedProduct.Price);
                    command.Parameters.Add("@workerId", SqlDbType.Int).Value = stockItem.Worker.WorkerId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AcceptOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[ApproveOrder]";

                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void ApproveDelivery(int orderId, DateTime deliveryDate, int delivereId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[ApproveDelivery]";

                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;
                    command.Parameters.Add("@deliveryDate", SqlDbType.DateTime2).Value = deliveryDate;
                    command.Parameters.Add("@delivererId", SqlDbType.Int).Value = delivereId;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
