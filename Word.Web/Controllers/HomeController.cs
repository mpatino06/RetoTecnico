using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Word.Web.Models;
using Word.Web.Services;

namespace Word.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ClientServices _services;
        private readonly IConfiguration _configuration;


        public HomeController(ILogger<HomeController> logger, IConfiguration config)
        {
            _logger = logger;
            _services = new ClientServices();
            _configuration = config;
        }


        public IActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> ValidateCountWords(string texto)
        {
            var ApiBaseUrl = _configuration["MyApiURL"].ToString();
            
            var result = await _services.PostCountWord(ApiBaseUrl, texto);

            return Json(result);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
