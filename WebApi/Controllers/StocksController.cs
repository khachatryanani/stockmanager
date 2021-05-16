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
        public IEnumerable<StockModel> GetStocks()
        {
            return _mapper.Map<IEnumerable<StockModel>>(_dataRep.GetStocks());
        }

        //[HttpGet("{id:int}")]
        //public StockModel GetStock(int id)
        //{
        //    return _mapper.Map<StockModel>(_dataRep.GetStock(id));
        //}

        [HttpGet("{id:int}")]
        public IEnumerable<StockItemModel> GetStockItems(int id)
        {
            return _mapper.Map<IEnumerable<StockItemModel>>(_dataRep.GetStockItems(id));
        }

        [HttpPost]
        public IActionResult CreateStockItem([FromBody] StockItemBaseModel stockItem)
        {
            _dataRep.CreateStockItem(_mapper.Map<StockItem>(stockItem));

            return Ok();
        }

    }
}
