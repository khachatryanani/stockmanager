using AutoMapper;
using DataAccess;
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
    public class ExpiredStockController : Controller
    {
        private readonly IDataRepository _dataRep;
        private readonly IMapper _mapper;

        public ExpiredStockController(IDataRepository dataRep, IMapper mapper)
        {
            _dataRep = dataRep;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<StockItemModel> GetExpiredStockItems()
        {
            return _mapper.Map<IEnumerable<StockItemModel>>(_dataRep.GetExpiredStockItems());
        }
    }
}
