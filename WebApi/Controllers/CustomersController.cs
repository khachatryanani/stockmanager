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
    public class CustomersController : ControllerBase
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public CustomersController(IDataRepository dataRep, IMapper mapper)
        {
            _dataRep = dataRep;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerDTO>>(_dataRep.GetCustomers());
        }

        [HttpGet("{id:int}")]
        public CustomerDTO GetCustomer(int id)
        {
            return _mapper.Map<CustomerDTO>(_dataRep.GetCustomer(id));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromQuery]CustomerDTO customerDTO)
        {
            _dataRep.CreateCustomer(_mapper.Map<Customer>(customerDTO));

            return Ok();
        }

        [HttpPut]
        public IActionResult UpdateCustomer([FromQuery] CustomerDTO customerDTO)
        {
            _dataRep.UpdateCustomer(_mapper.Map<Customer>(customerDTO));

            return Ok();
        }


        [HttpGet("{customerId:int}/Orders")]
        public IEnumerable<OrderDTO> GetCustomerOrders(int customerId)
        {
            return _mapper.Map<IEnumerable<OrderDTO>>(_dataRep.GetCustomerOrders(customerId));
        }
    }
}
