using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductHttpClient _client;
        public ProductsController(ProductHttpClient productHttpClient)
        {
            this._client = productHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _client.GetProducts();
            return View(products);
        }

        [HttpGet("Product")]
        public IActionResult Product()
        {
            return View(new ProductViewModel());
        }

        [HttpPost("[controller]/Product")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateProduct([FromForm] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (await _client.CreateProduct(product))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
            }

            return RedirectToAction("Product");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                if (!await _client.UpdateProduct(product))
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/[controller]/{id:int}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await _client.DeleteProduct(id);
            return RedirectToAction("Index");
        }
    }
}
