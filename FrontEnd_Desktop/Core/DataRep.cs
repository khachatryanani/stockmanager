using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
using AutoMapper;
using FrontEnd_Desktop.MVVM.Model;

namespace FrontEnd_Desktop.Core
{
    public class DataRep
    {
        private readonly DataRepository _dataRep;
        private readonly AutoMapper.Mapper _mapper;

        public DataRep(string connectionString)
        {
            this._dataRep = new DataRepository(connectionString);
            _mapper = Mapper.InitializeMapper();
        }

        public List<ProductDTO> GetProducts()
        {
            var productList = _dataRep.GetProducts();

            return _mapper.Map<IEnumerable<ProductDTO>>(productList) as List<ProductDTO>;
        }

        public List<CustomerDTO> GetCustomers()
        {
            var customerList = _dataRep.GetCustomers();
            return _mapper.Map<IEnumerable<CustomerDTO>>(customerList) as List<CustomerDTO>;
        }

        public List<WorkerDTO> GetWorkers()
        {
            var workerList = _dataRep.GetWorkers();

            return _mapper.Map<IEnumerable<WorkerDTO>>(workerList) as List<WorkerDTO>;
        }

        public List<StockDTO> GetStockItems()
        {
            var stockItemList = _dataRep.GetStockItems();

             return _mapper.Map<IEnumerable<StockDTO>>(stockItemList) as List<StockDTO>;
        }

        public List<OrderDTO> GetOrders()
        {
            var orderList = _dataRep.GetOrders();

            return _mapper.Map<IEnumerable<OrderDTO>>(orderList) as List<OrderDTO>;
        }

        public List<StockItemDTO> GetStockItem(int productId)
        {
            var stockItem = _dataRep.GetStockItem(productId);
            return _mapper.Map<IEnumerable<StockItemDTO>>(stockItem) as List<StockItemDTO>;
        }

        public OrderDTO GetOrder(int orderId)
        {
            var order = _dataRep.GetOrder(orderId);
            return _mapper.Map<OrderDTO>(order);
        }

        public void CreateStockItem(StockItemDTO stockItemDTO)
        {
            var stockItem = _mapper.Map<StockItem>(stockItemDTO);
            _dataRep.CreateStockItem(stockItem);
        }

        public void CreateOrder(OrderDTO orderDTO)
        {
            var order = _mapper.Map<Order>(orderDTO);
            _dataRep.CreateOrder(order);
        }
    }
}
