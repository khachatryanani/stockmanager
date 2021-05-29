using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using AutoMapper;
using FrontEnd_Desktop.MVVM.Model;

namespace FrontEnd_Desktop.Core
{
    public class DataRepService
    {
        private readonly IDataRepository _dataRep;
        private readonly AutoMapper.Mapper _mapper;

        public DataRepService(string connectionString)
        {
            this._dataRep = new DataRepository(connectionString);
            this._mapper = Mapper.InitializeMapper();
        }

        // Products
        public List<ProductDTO> GetProducts()
        {
            var productList = _dataRep.GetProducts();
            return _mapper.Map<IEnumerable<ProductDTO>>(productList) as List<ProductDTO>;
        }

        // Customers
        public List<CustomerDTO> GetCustomers()
        {
            var customerList = _dataRep.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customerList) as List<CustomerDTO>;
        }

        // Workers
        public List<WorkerDTO> GetWorkers()
        {
            var workerList = _dataRep.GetWorkers();
            return _mapper.Map<IEnumerable<WorkerDTO>>(workerList) as List<WorkerDTO>;
        }

        // Stocks
        public List<StockDTO> GetStocks()
        {
            var stocks = _dataRep.GetStocks();
            return _mapper.Map<IEnumerable<StockDTO>>(stocks) as List<StockDTO>;
        }

        public List<StockItemDTO> GetStockItems(int productId)
        {
            var stockItems = _dataRep.GetStockItems(productId);
            return _mapper.Map<IEnumerable<StockItemDTO>>(stockItems) as List<StockItemDTO>;
        }

        public void CreateStockItem(StockItemDTO stockItemDTO)
        {
            var stockItem = _mapper.Map<StockItem>(stockItemDTO);
            _dataRep.CreateStockItem(stockItem);
        }

        // Orders
        public List<OrderDTO> GetOrders()
        {
            var orders = _dataRep.GetOrders(null);
            return _mapper.Map<IEnumerable<OrderDTO>>(orders) as List<OrderDTO>;
        }

        public List<OrderItemDTO> GetOrderItems(int orderId)
        {
            var orderItems = _dataRep.GetOrderItems(orderId);
            return _mapper.Map<IEnumerable<OrderItemDTO>>(orderItems) as List<OrderItemDTO>;
        }

        public void UpdateOrder(OrderDTO orderDTO) 
        {
            var order = _mapper.Map<Order>(orderDTO);
            _dataRep.TryAcceptOrder(order);
        }     

        public void CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _dataRep.CreateOrder(order);
        }
    }
}
