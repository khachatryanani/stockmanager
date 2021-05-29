using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class CustomersController : Controller
    {
        private readonly CustomerHttpClient _client;
        public CustomersController(CustomerHttpClient customerHttpClient)
        {
            this._client = customerHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var customers = await _client.GetCustomers();
            return View(customers);
        }

        [HttpGet("Customer")]
        public IActionResult Customer()
        {
            return View(new CustomerViewModel());
        }

        [HttpPost("[controller]/Customer")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateCustomer([FromForm] CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                if (await _client.CreateCustomer(customer))
                {
                    return View("Index", await _client.GetCustomers());
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateCustomer([FromForm] CustomerViewModel customer)
        {
            if (ModelState.IsValid)
            {
                if (!await _client.UpdateCustomer(customer))
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/[controller]/{id:int}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _client.DeleteCustomer(id);
            return View("Index", await _client.GetCustomers());
        }
    }
}
