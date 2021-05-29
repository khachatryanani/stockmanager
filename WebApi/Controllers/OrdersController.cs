using AutoMapper;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public OrdersController(IDataRepository dataRep, IMapper mapper)
        {
            _dataRep = dataRep;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderBaseModel order)
        {
            _dataRep.CreateOrder(_mapper.Map<Order>(order));

            return Ok();
        }

        [HttpGet]
        public IEnumerable<OrderModel> GetOrders([FromQuery] string status)
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_dataRep.GetOrders(status));
           
        }

        [HttpGet("{id:int}")]
        public IEnumerable<OrderItemModel> GetOrderItems(int id)
        {
            return _mapper.Map<IEnumerable<OrderItemModel>>(_dataRep.GetOrderItems(id));
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateOrder([FromBody] OrderModel order)
        {
            var currentOrder = _dataRep.GetOrders(null).FirstOrDefault(o => o.OrderId == order.OrderId);
            if (currentOrder.Status == "Pending" && order.Status == "Accepted")
            {
                _dataRep.TryAcceptOrder(_mapper.Map<Order>(order));
                return NoContent();
            }
            else if (currentOrder.Status == "Accepted" && order.Status == "Delivered") 
            {
                _dataRep.TryApproveDelivery(_mapper.Map<Order>(order));
                return NoContent();
            }

            order.Status = currentOrder.Status;
            _dataRep.UpdateOrder(_mapper.Map<Order>(order));
            return NoContent();
        }
    }
}
