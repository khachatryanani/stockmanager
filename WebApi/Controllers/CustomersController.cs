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
        public IEnumerable<CustomerModel> GetCustomers()
        {
            return _mapper.Map<IEnumerable<CustomerModel>>(_dataRep.GetCustomers());
        }

        [HttpGet("{id:int}")]
        public CustomerModel GetCustomer(int id)
        {
            return _mapper.Map<CustomerModel>(_dataRep.GetCustomer(id));
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] CustomerModel customerDTO)
        {
            _dataRep.CreateCustomer(_mapper.Map<Customer>(customerDTO));

            return Ok();
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateCustomer(int id, [FromBody] CustomerModel customerDTO)
        {
            customerDTO.CustomerId = id;
            _dataRep.UpdateCustomer(_mapper.Map<Customer>(customerDTO));

            return Ok();
        }


        [HttpGet("{customerId:int}/Orders")]
        public IEnumerable<OrderBaseModel> GetCustomerOrders(int customerId)
        {
            return _mapper.Map<IEnumerable<OrderBaseModel>>(_dataRep.GetCustomerOrders(customerId));
        }
    }
}
