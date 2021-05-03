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
        public IEnumerable<OrderDTO> GetOrders()
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(_dataRep.GetOrders());
        }

        [HttpGet("{id:int}")]
        public IEnumerable<OrderItemDTO> GetOrderItems(int id)
        {
            return _mapper.Map<IEnumerable<OrderItemDTO>>(_dataRep.GetOrderItems(id));
        }



        [HttpPost]
        public IActionResult CreateOrder([FromQuery] OrderDTO order)
        {
            _dataRep.CreateOrder(_mapper.Map<Order>(order));

            return Ok();
        }

    }
}
