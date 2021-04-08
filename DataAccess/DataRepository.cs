using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class DataRepository
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

        public List<Product> GetProductsList()
        {
            if (products == null)
            {
                products = GetProducts();
            }

            return products;
        }

        public List<Worker> GetWorkersList()
        {
            if (workers == null)
            {
                workers = GetWorkers();
            }

            return workers;
        }

        public List<Customer> GetCustomersList()
        {
            if (customers == null)
            {
                customers = GetCustomers();
            }

            return customers;
        }

        public List<InStockItem> GetInStockItems()
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetInStockItems]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var inStockItems = new List<InStockItem>();
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
                                inStockItems.Add(
                                    new InStockItem
                                    {
                                        ProductId = reader.GetInt32(ordProductId),
                                        ProductName = reader.GetString(ordProductName),
                                        ProductType = reader.GetString(ordProductType),
                                        TotalQuantity = reader.GetInt32(ordTotal),
                                        AverageUnitPrice = Convert.ToDouble(reader.GetDecimal(ordPrice)),
                                        MeasurementUnit = reader.GetString(ordMeasurement)
                                    }); ;
                            }
                        }
                        return inStockItems;
                    }
                }
            }
        }

        private List<Product> GetProducts()
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetProducts]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var products = new List<Product>();
                        if (reader.HasRows)
                        {
                            int ordProductId = reader.GetOrdinal("ProductId");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordMeasurement = reader.GetOrdinal("MeasurementUnit");

                            while (reader.Read())
                            {
                                products.Add(
                                    new Product
                                    {
                                        ProductId = reader.GetInt32(ordProductId),
                                        Name = reader.GetString(ordProductName),
                                        Unit = reader.GetString(ordMeasurement)
                                    });
                            }
                        }

                        return products;
                    }
                }
            }
        }

        private List<Worker> GetWorkers()
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetWorkers]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var workers = new List<Worker>();
                        if (reader.HasRows)
                        {
                            int ordWorkerId = reader.GetOrdinal("WorkerId");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordEmail = reader.GetOrdinal("Email");

                            while (reader.Read())
                            {
                                workers.Add(
                                    new Worker
                                    {
                                        WorkerId = reader.GetInt32(ordWorkerId),
                                        Name = reader.GetString(ordFirstName),
                                        Surname = reader.GetString(ordLastName),
                                        Email = reader.GetString(ordEmail)
                                    });
                            }
                        }

                        return workers;
                    }
                }
            }
        }

        private List<Customer> GetCustomers()
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetCustomers]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var customers = new List<Customer>();
                        if (reader.HasRows)
                        {
                            int ordCustomerId = reader.GetOrdinal("CustomerId");
                            int ordCustomertName = reader.GetOrdinal("CustomerName");
                            int ordCustomerAddress = reader.GetOrdinal("CustomerAddress");
                            int ordPhoneNumber = reader.GetOrdinal("PhoneNumber");

                            while (reader.Read())
                            {
                                customers.Add(
                                    new Customer
                                    {
                                        CustomerId = reader.GetInt32(ordCustomerId),
                                        Name = reader.GetString(ordCustomertName),
                                        Address = reader.GetString(ordCustomerAddress),
                                        Phone = reader.GetString(ordPhoneNumber)
                                    });
                            }
                        }

                        return customers;
                    }
                }
            }
        }

        public List<InStockItemDetails> GetStockedProductDetails(int productId)
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStockedProductDetails]";
                    command.Parameters.Add("@productId", SqlDbType.Int).Value = productId;

                    using (SqlDataReader reader = command.ExecuteReader()) 
                    {
                        var stockDetails = new List<InStockItemDetails>();
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
                                stockDetails.Add(
                                    new InStockItemDetails
                                    {
                                        ProductId = reader.GetInt32(ordProductId),
                                        ProductName = reader.GetString(ordProductName),
                                        ProductType = reader.GetString(ordProductType),
                                        Price = reader.GetDecimal(ordPrice),
                                        MeasurementUnit = reader.GetString(ordMUnit),
                                        StockedDate = reader.GetDateTime(ordStockedDate),
                                        ProductionDate = reader.GetDateTime(ordProductionDate),
                                        ExpirationDate = reader.GetDateTime(ordExpirationDate),
                                        Quantity = reader.GetInt32(ordQuantity),
                                        WorkerName = reader.GetString(ordWorker),
                                        WorkerId = reader.GetInt32(ordWorkerId)
                                    });
                            }
                        }

                        return stockDetails;
                    }     
                } 
            }
        }

        public List<Order> GetOrders()
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
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

                                orders.Add(
                                    new Order
                                    {
                                        OrderId = reader.GetInt32(ordOrderId),
                                        CustomerName = reader.GetString(ordCustomerName),
                                        CustomerAddress = reader.GetString(ordCustomerAddress),
                                        TotalPrice = Convert.ToDouble(reader.GetDecimal(ordTotalPrice)),
                                        ReceivedDate = reader.GetDateTime(ordReceivedDate),
                                        ReceivedBy = reader.GetString(ordReceivedBy),
                                        DeliveryDate = reader.IsDBNull(ordDeliveryDate) ? default : reader.GetDateTime(ordDeliveryDate),
                                        DeliveredBy = reader.IsDBNull(ordDeliveredBy) ? default : reader.GetString(ordDeliveredBy),
                                        Status = reader.GetString(ordStatus)
                                    });
                            }
                        }

                        return orders;
                    }  
                }   
            }
        }

        public List<OrderItem> GetOrderDetails(int orderId)
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
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
                                orderItems.Add(
                                    new OrderItem
                                    {
                                        OrderId = reader.GetInt32(ordOrderId),
                                        ProductName = reader.GetString(ordProductName),
                                        MeasurementUnit = reader.GetString(ordUnit),
                                        Quantity = reader.GetInt32(ordQuantity),
                                        Price = Convert.ToDouble(reader.GetDecimal(ordUnitPrice)),
                                        Status = reader.GetString(ordStatus)
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

        public void CreateNewOrder(NewOrder orderItem)
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateNewOrder]";


                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = orderItem.CustomerId;
                    command.Parameters.Add("@recievedDate", SqlDbType.DateTime2).Value = orderItem.ReceivedDate;
                    command.Parameters.Add("@receiverId", SqlDbType.Int).Value = orderItem.ReceivedBy;
                    command.Parameters.Add("@productList", SqlDbType.Structured).Value = orderItem.ProductList.ConvertToProductsDataTable();

                    command.ExecuteNonQuery();
                }                    
            }
        }

        public void CreateNewStockItem(NewStockItem stockItem)
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand()) 
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[InStockNewItem]";

                    command.Parameters.Add("@productId", SqlDbType.Int).Value = stockItem.ProductId;
                    command.Parameters.Add("@productionDate", SqlDbType.DateTime2).Value = stockItem.ProductionDate;
                    command.Parameters.Add("@stockedDate", SqlDbType.DateTime2).Value = stockItem.StockedDate;
                    command.Parameters.Add("@producedQuantity", SqlDbType.Int).Value = stockItem.Quantity;
                    command.Parameters.Add("@unitPrice", SqlDbType.Decimal).Value = stockItem.Price;
                    command.Parameters.Add("@workerId", SqlDbType.Int).Value = stockItem.WorkerId;

                    command.ExecuteNonQuery();
                }
            }
        }

        public void AcceptOrder(int orderId)
        {
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
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
            using (SqlConnection connection = ConnectionManager.ConnectToDb(this.connectionString))
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
