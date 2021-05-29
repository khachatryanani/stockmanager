using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace DataAccess
{
    public class DataRepository : IDataRepository
    {
        private readonly string connectionString;

        public DataRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        // Stocks
        public void CreateStockItem(StockItem stockItem)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateStockItem]";

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
        public List<Stock> GetStocks()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStocks]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var stocks = new List<Stock>();
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

                                stocks.Add(
                                    new Stock
                                    {
                                        TotalQuantity = reader.GetInt32(ordTotal),
                                        StockedProduct = stockedProduct
                                    });
                            }
                        }
                        return stocks;
                    }
                }
            }
        }
        public List<StockItem> GetExpiredStockItems()
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetExpiredInStockItems]";

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var stockItems = new List<StockItem>();
                        if (reader.HasRows)
                        {
                            int ordStockId = reader.GetOrdinal("StockId");
                            int ordProductId = reader.GetOrdinal("ProductId");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordProductType = reader.GetOrdinal("ProductType");
                            int ordPrice = reader.GetOrdinal("UnitPrice");
                            int ordMUnit = reader.GetOrdinal("MeasurementUnit");
                            int ordStockedDate = reader.GetOrdinal("StockedDate");
                            int ordProductionDate = reader.GetOrdinal("ProductionDate");
                            int ordExpirationDate = reader.GetOrdinal("ExpirationDate");
                            int ordQuantity = reader.GetOrdinal("ActualQuantity");
                            int ordWorker = reader.GetOrdinal("CreatedBy");


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
                                    Name = reader.GetString(ordWorker)
                                };

                                var stockItem =
                                    new StockItem
                                    {
                                        StockId = reader.GetInt32(ordStockId),
                                        StockedProduct = stockedProduct,
                                        StockedDate = reader.GetDateTime(ordStockedDate),
                                        ProductionDate = reader.GetDateTime(ordProductionDate),
                                        ExpirationDate = reader.GetDateTime(ordExpirationDate),
                                        Quantity = reader.GetInt32(ordQuantity),
                                        Worker = worker
                                    };
                                stockItems.Add(stockItem);
                            }

                        }

                        return stockItems;
                    }
                }
            }
        }
        public StockItem GetStockItem(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStockItem]";
                    command.Parameters.Add("@stockItemId", SqlDbType.Int).Value = itemId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ordProductId = reader.GetOrdinal("ProductId");
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

                            var stockItem =
                                new StockItem
                                {
                                    StockedProduct = stockedProduct,
                                    StockedDate = reader.GetDateTime(ordStockedDate),
                                    ProductionDate = reader.GetDateTime(ordProductionDate),
                                    ExpirationDate = reader.GetDateTime(ordExpirationDate),
                                    Quantity = reader.GetInt32(ordQuantity),
                                    Worker = worker
                                };
                            return stockItem;
                        }

                        return new StockItem();
                    }
                }
            }
        }
        public List<StockItem> GetStockItems(int productId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetStockItems]";
                    command.Parameters.Add("@productId", SqlDbType.Int).Value = productId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var stockItems = new List<StockItem>();
                        if (reader.HasRows)
                        {
                            int ordProductId = reader.GetOrdinal("ProductId");
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

                                stockItems.Add(
                                    new StockItem
                                    {
                                        StockedProduct = stockedProduct,
                                        StockedDate = reader.GetDateTime(ordStockedDate),
                                        ProductionDate = reader.GetDateTime(ordProductionDate),
                                        ExpirationDate = reader.GetDateTime(ordExpirationDate),
                                        Quantity = reader.GetInt32(ordQuantity),
                                        Worker = worker
                                    });
                            }
                        }

                        return stockItems;
                    }
                }
            }
        }

        // Products
        public void CreateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateProduct]";

                    command.Parameters.Add("@productName", SqlDbType.VarChar).Value = product.Name;
                    command.Parameters.Add("@productType", SqlDbType.Int).Value = product.TypeId;
                    command.Parameters.Add("@productCategory", SqlDbType.Char).Value = product.Category;
                    command.Parameters.Add("@measurementUnit", SqlDbType.Int).Value = product.UnitId;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Product> GetProducts()
        {
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
                            int ordProductType = reader.GetOrdinal("ProductType");
                            int ordMeasurement = reader.GetOrdinal("MeasurementUnit");

                            while (reader.Read())
                            {
                                productList.Add(
                                    new Product
                                    {
                                        ProductId = reader.GetInt32(ordProductId),
                                        Type = reader.GetString(ordProductType),
                                        Name = reader.GetString(ordProductName),
                                        Unit = reader.GetString(ordMeasurement)
                                    });
                            }
                        }
                        
                        return productList;
                    }
                }
            }
        }
        public void UpdateProduct(Product product)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateProduct]";

                    command.Parameters.Add("@productId", SqlDbType.Int).Value = product.ProductId;
                    command.Parameters.Add("@productName", SqlDbType.VarChar).Value = product.Name;
                    command.Parameters.Add("@productType", SqlDbType.Int).Value = product.TypeId;
                    command.Parameters.Add("@measurementUnit", SqlDbType.Int).Value = product.UnitId;

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteProduct(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[DeleteProduct]";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        // Workers
        public void CreateWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateWorker]";

                    command.Parameters.Add("@fName", SqlDbType.VarChar).Value = worker.Name;
                    command.Parameters.Add("@lName", SqlDbType.VarChar).Value = worker.Surname;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = worker.Email;
                    command.Parameters.Add("@password", SqlDbType.Int).Value = worker.Password;

                    command.ExecuteNonQuery();
                }
            }

        }
        public List<Worker> GetWorkers()
        {
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
                            int ordPassword = reader.GetOrdinal("Password");

                            while (reader.Read())
                            {
                                workerList.Add(
                                    new Worker
                                    {
                                        WorkerId = reader.GetInt32(ordWorkerId),
                                        Name = reader.GetString(ordFirstName),
                                        Surname = reader.GetString(ordLastName),
                                        Email = reader.GetString(ordEmail),
                                        Password = reader.GetInt32(ordPassword)

                                    });
                            }
                        }
                       
                        return workerList;
                    }
                }
            }
        }
        public Worker GetWorker(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetWorker]";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Worker worker = new Worker();
                        if (reader.HasRows)
                        {
                            int ordWorkerId = reader.GetOrdinal("WorkerId");
                            int ordFirstName = reader.GetOrdinal("FirstName");
                            int ordLastName = reader.GetOrdinal("LastName");
                            int ordEmail = reader.GetOrdinal("Email");
                            int ordPassword = reader.GetOrdinal("Password");


                            worker.WorkerId = reader.GetInt32(ordWorkerId);
                            worker.Name = reader.GetString(ordFirstName);
                            worker.Surname = reader.GetString(ordLastName);
                            worker.Email = reader.GetString(ordEmail);
                            worker.Password = reader.GetInt32(ordPassword);
                        }

                        return worker;
                    }
                }
            }
        }
        public void UpdateWorker(Worker worker)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateWorker]";

                    command.Parameters.Add("@id", SqlDbType.Int).Value = worker.WorkerId;
                    command.Parameters.Add("@fName", SqlDbType.VarChar).Value = worker.Name;
                    command.Parameters.Add("@lName", SqlDbType.VarChar).Value = worker.Surname;
                    command.Parameters.Add("@email", SqlDbType.VarChar).Value = worker.Email;
                    command.Parameters.Add("@password", SqlDbType.Int).Value = worker.Password;

                    command.ExecuteNonQuery();
                }
            }
        }
        public void DeleteWorker(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[DeleteWorker]";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    command.ExecuteNonQuery();
                }
            }
        }

        // Customers
        public void CreateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateCustomer]";

                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = customer.Name;
                    command.Parameters.Add("@address", SqlDbType.VarChar).Value = customer.Address;
                    command.Parameters.Add("@phone", SqlDbType.NChar).Value = customer.Phone;

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Customer> GetCustomers()
        {
           
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

                        return customerList;
                    }
                }
            }
        }
        public Customer GetCustomer(int id)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetCustomer]";
                    command.Parameters.Add("@id", SqlDbType.Int).Value = id;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var customer = new Customer();
                        if (reader.HasRows)
                        {
                            int ordCustomerId = reader.GetOrdinal("CustomerId");
                            int ordCustomertName = reader.GetOrdinal("CustomerName");
                            int ordCustomerAddress = reader.GetOrdinal("CustomerAddress");
                            int ordPhoneNumber = reader.GetOrdinal("PhoneNumber");

                            customer.CustomerId = reader.GetInt32(ordCustomerId);
                            customer.Name = reader.GetString(ordCustomertName);
                            customer.Address = reader.GetString(ordCustomerAddress);
                            customer.Phone = reader.GetString(ordPhoneNumber);
                        }

                        return customer;
                    }
                }
            }
        }
        public void UpdateCustomer(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateCustomer]";

                    command.Parameters.Add("@id", SqlDbType.VarChar).Value = customer.CustomerId;
                    command.Parameters.Add("@name", SqlDbType.VarChar).Value = customer.Name;
                    command.Parameters.Add("@address", SqlDbType.VarChar).Value = customer.Address;
                    command.Parameters.Add("@phone", SqlDbType.NChar).Value = customer.Phone;

                    command.ExecuteNonQuery();
                }
            }
        }

        // Orders
        public void CreateOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[CreateOrder]";

                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = order.Customer.CustomerId;
                    command.Parameters.Add("@recievedDate", SqlDbType.DateTime2).Value = order.ReceivedDate;
                    command.Parameters.Add("@receiverId", SqlDbType.Int).Value = order.Receiver.WorkerId;
                    command.Parameters.Add("@productList", SqlDbType.Structured).Value = order.OrderItemList.ConvertToProductsDataTable();

                    command.ExecuteNonQuery();
                }
            }
        }
        public List<Order> GetCustomerOrders(int customerId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetCustomerOrders]";
                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = customerId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var orders = new List<Order>();
                        if (reader.HasRows)
                        {
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordCustomerId = reader.GetOrdinal("CustomerId");
                            int ordCustomerName = reader.GetOrdinal("CustomerName");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordReceivedDate = reader.GetOrdinal("ReceivedDate");
                            int ordReceivedBy = reader.GetOrdinal("ReceivedBy");
                            int ordReceivedById = reader.GetOrdinal("ReceivedById");
                            int ordDeliveryDate = reader.GetOrdinal("DeliveredDate");
                            int ordDeliveredBy = reader.GetOrdinal("DeliveredBy");
                            int ordDeliveredById = reader.GetOrdinal("DeliveredById");

                            int ordStatus = reader.GetOrdinal("Status");

                            while (reader.Read())
                            {
                                var customer = new Customer
                                {
                                    CustomerId = reader.GetInt32(ordCustomerId),
                                    Name = reader.GetString(ordCustomerName)
                                };
                                var receiver = new Worker
                                {
                                    Name = reader.GetString(ordReceivedBy),
                                    WorkerId = reader.GetInt32(ordReceivedById)
                                };

                                var deliverer = new Worker
                                {
                                    Name = reader.IsDBNull(ordDeliveredBy) ? default : reader.GetString(ordDeliveredBy),
                                    WorkerId = reader.IsDBNull(ordDeliveredById) ? default : reader.GetInt32(ordDeliveredById)

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
        public List<Order> GetOrders(string status)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetOrders]";
                    if (!string.IsNullOrEmpty(status)) 
                    {
                        command.Parameters.Add("@orderStatus", SqlDbType.VarChar).Value = status;
                    }

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var orders = new List<Order>();
                        if (reader.HasRows)
                        {
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordCustomerId = reader.GetOrdinal("CustomerId");
                            int ordCustomerName = reader.GetOrdinal("CustomerName");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordReceivedDate = reader.GetOrdinal("ReceivedDate");
                            int ordReceiverId = reader.GetOrdinal("ReceiverId");
                            int ordReceiverFirstName = reader.GetOrdinal("ReceiverFirstName");
                            int ordReceiverLastName = reader.GetOrdinal("ReceiverLastName");
                            int ordDeliveryDate = reader.GetOrdinal("DeliveredDate");
                            int ordDelivererId = reader.GetOrdinal("DelivererId");
                            int ordDelivereFirstName = reader.GetOrdinal("DelivererFirstName");
                            int ordDelivererLastName = reader.GetOrdinal("DelivererLastName");
                            int ordStatus = reader.GetOrdinal("Status");

                            while (reader.Read())
                            {
                                var customer = new Customer
                                {
                                    Name = reader.GetString(ordCustomerName),
                                    CustomerId = reader.GetInt32(ordCustomerId),
                                };

                                var receiver = new Worker
                                {
                                    WorkerId = reader.GetInt32(ordReceiverId),
                                    Name = reader.GetString(ordReceiverFirstName),
                                    Surname = reader.GetString(ordReceiverLastName),
                                };

                                var deliverer = new Worker
                                {
                                    WorkerId = reader.IsDBNull(ordDelivererId) ? default : reader.GetInt32(ordDelivererId),
                                    Name = reader.IsDBNull(ordDelivereFirstName) ? default : reader.GetString(ordDelivereFirstName),
                                    Surname = reader.IsDBNull(ordDelivererLastName) ? default : reader.GetString(ordDelivererLastName)
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
        public List<OrderItem> GetOrderItems(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetOrderItems]";
                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        var orderItems = new List<OrderItem>();
                        if (reader.HasRows)
                        {
                            int ordItemId = reader.GetOrdinal("ItemId");
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordProductId = reader.GetOrdinal("ProductId");

                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordUnit = reader.GetOrdinal("MeasurementUnit");
                            int ordQuantity = reader.GetOrdinal("Quantity");
                            int ordUnitPrice = reader.GetOrdinal("Price");
                            int ordStatus = reader.GetOrdinal("Status");

                            while (reader.Read())
                            {
                                var orderedProduct = new Product
                                {
                                    ProductId = reader.GetInt32(ordProductId),
                                    Name = reader.GetString(ordProductName),
                                    Unit = reader.GetString(ordUnit),
                                    Price = Convert.ToDouble(reader.GetDecimal(ordUnitPrice))
                                };

                                orderItems.Add(
                                    new OrderItem
                                    {
                                        ItemId = reader.GetInt32(ordItemId),
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
        public Order GetOrder(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetOrder]";
                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = orderId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordCustomerId = reader.GetOrdinal("CustomerId");
                            int ordCustomerName = reader.GetOrdinal("CustomerName");
                            int ordTotalPrice = reader.GetOrdinal("TotalPrice");
                            int ordReceivedDate = reader.GetOrdinal("ReceivedDate");
                            int ordReceiverId = reader.GetOrdinal("ReceiverId");
                            int ordReceiverFirstName = reader.GetOrdinal("ReceiverFirstName");
                            int ordReceiverLastName = reader.GetOrdinal("ReceiverLastName");
                            int ordDeliveryDate = reader.GetOrdinal("DeliveredDate");
                            int ordDelivererId = reader.GetOrdinal("DelivererId");
                            int ordDelivereFirstName = reader.GetOrdinal("DelivererFirstName");
                            int ordDelivererLastName = reader.GetOrdinal("DelivererLastName");
                            int ordStatus = reader.GetOrdinal("Status");
                            
                            
                            var customer = new Customer
                            {
                                Name = reader.GetString(ordCustomerName),
                                CustomerId = reader.GetInt32(ordCustomerId),
                            };

                            var receiver = new Worker
                            {
                                WorkerId = reader.GetInt32(ordReceiverId),
                                Name = reader.GetString(ordReceiverFirstName),
                                Surname = reader.GetString(ordReceiverLastName),
                            };

                            var deliverer = new Worker
                            {
                                WorkerId = reader.GetInt32(ordDelivererId),
                                Name = reader.IsDBNull(ordDelivereFirstName) ? default : reader.GetString(ordDelivereFirstName),
                                Surname = reader.IsDBNull(ordDelivererLastName) ? default : reader.GetString(ordDelivererLastName)
                            };

                            var order =
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
                                };

                            return order;
                        }

                        return new Order();
                    }
                }
            }
        }
        public OrderItem GetOrderItem(int itemId)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[GetOrderItem]";
                    command.Parameters.Add("@itemId", SqlDbType.Int).Value = itemId;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            int ordOrderId = reader.GetOrdinal("OrderId");
                            int ordProductName = reader.GetOrdinal("ProductName");
                            int ordUnit = reader.GetOrdinal("MeasurementUnit");
                            int ordQuantity = reader.GetOrdinal("Quantity");
                            int ordUnitPrice = reader.GetOrdinal("Price");
                            int ordStatus = reader.GetOrdinal("Status");


                            var orderedProduct = new Product
                            {
                                Name = reader.GetString(ordProductName),
                                Unit = reader.GetString(ordUnit),
                                Price = Convert.ToDouble(reader.GetDecimal(ordUnitPrice))
                            };

                            var orderItem = new OrderItem
                            {
                                OrderId = reader.GetInt32(ordOrderId),
                                OrderedProduct = orderedProduct,
                                Quantity = reader.GetInt32(ordQuantity),
                                OrderItemStatus = reader.GetString(ordStatus)
                            };

                            return orderItem;

                        }

                        return new OrderItem();
                    }
                }
            }
        }
        public void UpdateOrder(Order order) 
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateOrder]";

                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = order.OrderId;
                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = order.Customer.CustomerId;
                    command.Parameters.Add("@receivedDate", SqlDbType.DateTime2).Value = order.ReceivedDate;
                    command.Parameters.Add("@receiverId", SqlDbType.Int).Value = order.Receiver.WorkerId;
                    command.Parameters.Add("@status", SqlDbType.VarChar).Value = order.Status;


                    command.ExecuteNonQuery();
                }
            }
        }
        public void AcceptOrder(Order order)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateOrder]";

                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = order.OrderId;
                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = order.Customer.CustomerId;
                    command.Parameters.Add("@receivedDate", SqlDbType.DateTime2).Value = order.ReceivedDate;
                    command.Parameters.Add("@receiverId", SqlDbType.Int).Value = order.Receiver.WorkerId;
                    command.Parameters.Add("@status", SqlDbType.VarChar).Value = "Accepted";


                    command.ExecuteNonQuery();
                }
            }
        }
        public void ApproveDelivery(Order order)
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateOrder]";

                    command.Parameters.Add("@orderId", SqlDbType.Int).Value = order.OrderId;
                    command.Parameters.Add("@customerId", SqlDbType.Int).Value = order.Customer.CustomerId;
                    command.Parameters.Add("@receivedDate", SqlDbType.DateTime2).Value = order.ReceivedDate;
                    command.Parameters.Add("@receiverId", SqlDbType.Int).Value = order.Receiver.WorkerId;

                    command.Parameters.Add("@deliveryDate", SqlDbType.DateTime2).Value = order.DeliveryDate;
                    command.Parameters.Add("@delivererId", SqlDbType.Int).Value = order.Deliverer.WorkerId;
                    command.Parameters.Add("@status", SqlDbType.VarChar).Value = "Delivered";


                    command.ExecuteNonQuery();
                }
            }
        }
        public bool TryAcceptOrder(Order order) 
        {
            var orderItems = GetOrderItems(order.OrderId);
            var stocks = GetStocks();
            foreach (var item in orderItems)
            {
                if (item.Quantity <= stocks.Find(p => p.StockedProduct.ProductId == item.OrderedProduct.ProductId).TotalQuantity) 
                {
                    item.OrderItemStatus = "Accepted";
                    UpdateOrderItem(item);
                }
            }

            if (orderItems.All(o => o.OrderItemStatus == "Accepted")) 
            {
                AcceptOrder(order);
                return true;
            }

            return false;
        }
        public bool TryApproveDelivery(Order order) 
        {
            var orderItems = GetOrderItems(order.OrderId);
            foreach (var item in orderItems)
            {
                if (item.OrderItemStatus == "Accepted")
                {
                    item.OrderItemStatus = "Delivered";
                    UpdateOrderItem(item);
                }
            }

            ApproveDelivery(order);
            return true;
        }
        public void UpdateOrderItem(OrderItem orderItem) 
        {
            using (SqlConnection connection = new SqlConnection(this.connectionString))
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.CommandText = "[dbo].[UpdateOrderItem]";

                    command.Parameters.Add("@itemId", SqlDbType.Int).Value = orderItem.ItemId;
                    command.Parameters.Add("@productId", SqlDbType.Int).Value = orderItem.OrderedProduct.ProductId;
                    command.Parameters.Add("@quantity", SqlDbType.Int).Value = orderItem.Quantity;
                    command.Parameters.Add("@status", SqlDbType.VarChar).Value = orderItem.OrderItemStatus;

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
