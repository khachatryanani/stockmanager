using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    [Route("[controller]")]
    public class StocksController : Controller
    {
        private readonly StockHttpClient _client;

        public StocksController(StockHttpClient stockHttpClient)
        {
            this._client = stockHttpClient;
        }

        [HttpGet]
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

        [HttpGet("/[controller]/StockItem")]
        public async Task<IActionResult> StockItem() 
        {
            var products = await _client.GetProducts();
            var workers = await _client.GetWorkers();

            ViewData["Products"] = products;
            ViewData["Workers"] = workers;

            return View(new StockItemBaseViewModel());
        }

        [HttpPost("[controller]/StockItem")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddStockItem([FromForm] StockItemBaseViewModel stockItem) 
        {
            if (ModelState.IsValid) 
            {
                var result = await _client.CreateStockItem(stockItem);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            var products = await _client.GetProducts();
            var workers = await _client.GetWorkers();

            ViewData["Products"] = products;
            ViewData["Workers"] = workers;

            return RedirectToAction("StockItem");
        }
    }
}
