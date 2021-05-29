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
    public class ProductsController : ControllerBase
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public ProductsController(IDataRepository dataRep, IMapper mapper)
        {
            _dataRep = dataRep;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductModel productDTO)
        {
            _dataRep.CreateProduct(_mapper.Map<Product>(productDTO));

            return Ok();
        }

        [HttpGet]
        public IEnumerable<ProductModel> GetProducts()
        {
            return _mapper.Map<IEnumerable<ProductModel>>(_dataRep.GetProducts());
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel productDTO)
        {
            productDTO.ProductId = id;
            _dataRep.UpdateProduct(_mapper.Map<Product>(productDTO));

            return Ok();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct(int id)
        {
            _dataRep.DeleteProduct(id);

            return Ok();
        }
    }
}
