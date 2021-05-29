using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class ExpiredStockController : Controller
    {
        private readonly StockHttpClient _client;
        public ExpiredStockController(StockHttpClient stockHttpClient)
        {
            this._client = stockHttpClient;
        }


        public async Task<IActionResult> Index(string status)
        {
            var stockItems = await _client.GetExpiredStockItems();
            return View(stockItems);
        }
    }
}
