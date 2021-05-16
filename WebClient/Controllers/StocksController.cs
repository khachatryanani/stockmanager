using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebClient.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : Controller
    {
        private readonly DataHttpClient _client;
        public StocksController(DataHttpClient dataHttpClient)
        {
            this._client = dataHttpClient;
        }
        public async Task<IActionResult> Index()
        {
            var stocks = await _client.GetStocks();
            return View(stocks);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> StockItems(int id)
        {
            var stockItems = await _client.GetStockItems(id);
            return View(stockItems);
        }
    }
}
