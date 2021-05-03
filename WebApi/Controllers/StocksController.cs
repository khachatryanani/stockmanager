using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess;
using AutoMapper;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public StocksController(IDataRepository dataRep, IMapper mapper)
        {
            _dataRep = dataRep;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StockDTO> GetStocks() 
        {
            return _mapper.Map<IEnumerable<StockDTO>>(_dataRep.GetStocks());
        }

        [HttpGet("{id:int}")]
        public IEnumerable<StockItemDTO> GetStockItems(int id)
        {
            return _mapper.Map<IEnumerable<StockItemDTO>>(_dataRep.GetStockItems(id));
        }

        [HttpPost]
        public IActionResult CreateStockItem([FromQuery] StockItemDTO stockItem)
        {
            _dataRep.CreateStockItem(_mapper.Map<StockItem>(stockItem));

            return Ok();
        }

    }
}
