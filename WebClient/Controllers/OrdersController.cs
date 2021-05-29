using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class OrdersController : Controller
    {
        private readonly OrderHttpClient _client;
        public OrdersController(OrderHttpClient orderHttpClient)
        {
            this._client = orderHttpClient;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string status)
        {
            if (status == "Accepted")
            {
                var deliveryOrders = await _client.GetOrders("Accepted");
                deliveryOrders.AddRange(await _client.GetOrders("Delivered"));
                return View("Delivery", deliveryOrders);
            }

            var orders = await _client.GetOrders(status);

            return View(orders);
        }

        [HttpGet]
        [Route("/[controller]/{id:int}")]
        public async Task<IActionResult> OrderItems(int id)
        {
            var orders = await _client.GetOrders("");
            ViewData["Order"] = orders.First(o => o.orderId == id);

            var orderItems = await _client.GetOrderItems(id);
            orderItems.ForEach(o => o.total = $"{double.Parse(o.unitPrice, NumberStyles.Currency) * o.quantity:C}");
            return View(orderItems);
        }

        [HttpGet("/[controller]/Order")]
        public async Task<IActionResult> Order()
        {
            var products = await _client.GetProducts();
            var workers = await _client.GetWorkers();
            var customers = await _client.GetCustomers();

            ViewData["Products"] = products;
            ViewData["Workers"] = workers;
            ViewData["Customers"] = customers;
            return View(new OrderBaseViewModel());
        }

        [HttpPost("[controller]/Order")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateOrder([FromForm] OrderBaseViewModel order)
        {
            if (ModelState.IsValid)
            {
                var result = await _client.CreateOrder(order);
                if (result)
                {
                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Order");
        }


        [HttpPost("[controller]/{id}")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateOrder([FromRoute]int id, [FromForm] OrderViewModel order)
        {
            order.orderId = id;
            var result = await _client.UpdateOrder(order);
            if (result) 
            {
                return RedirectToAction("Index");
            }

            return RedirectToAction("OrderItems");
        }
    }
}
