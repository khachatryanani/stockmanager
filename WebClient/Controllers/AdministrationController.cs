using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class AdministrationController : Controller
    {
        private readonly DataHttpClient _client;
        public AdministrationController(DataHttpClient dataHttpClient)
        {
            this._client = dataHttpClient;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
