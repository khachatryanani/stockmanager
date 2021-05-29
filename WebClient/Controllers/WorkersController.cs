using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebClient.Models;

namespace WebClient.Controllers
{
    public class WorkersController : Controller
    {
        private readonly WorkerHttpClient _client;

        public WorkersController(WorkerHttpClient workerHttpClient)
        {
            this._client = workerHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var workers = await _client.GetWorkers();
            return View(workers);
        }

        [HttpGet("Worker")]
        public IActionResult Worker()
        {
            return View(new WorkerViewModel());
        }

        [HttpPost("[controller]/Worker")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> CreateWorker([FromForm] WorkerViewModel worker)
        {
            if (ModelState.IsValid)
            {
                if (await _client.CreateWorker(worker))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
            }

            return RedirectToAction("Worker");
        }

        [HttpPost]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> UpdateWorker([FromForm] WorkerViewModel worker)
        {
            if(ModelState.IsValid)
            {
                if (!await _client.UpdateWorker(worker))
                {
                    ModelState.AddModelError("", "Something went wrong!");
                }
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [Route("/[controller]/{id:int}")]
        public async Task<IActionResult> DeleteWorker(int id)
        {
            await _client.DeleteWorker(id);
            return RedirectToAction("Index");
        }
    }
}
