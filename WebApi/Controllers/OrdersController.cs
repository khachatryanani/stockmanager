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

        [HttpGet]
        public IEnumerable<OrderModel> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderModel>>(_dataRep.GetOrders());
        }

        [HttpGet("{id:int}")]
        public OrderModel GetOrder(int id)
        {
            return _mapper.Map<OrderModel>(_dataRep.GetOrder(id));
        }


        [HttpGet("{id:int}/OrderItems")]
        public IEnumerable<OrderItemModel> GetOrderItems(int id)
        {
            return _mapper.Map<IEnumerable<OrderItemModel>>(_dataRep.GetOrderItems(id));
        }

        [HttpPost]
        public IActionResult CreateOrder([FromBody] OrderBaseModel order)
        {
            _dataRep.CreateOrder(_mapper.Map<Order>(order));

            return Ok();
        }

    }
}
