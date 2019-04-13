using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Insta.Models;
using Insta.Services;

namespace Insta.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScrapService _scrapService;

        public HomeController(IScrapService scrapService)
        {
            _scrapService = scrapService;
        }
        public IActionResult Index()
        {
            _scrapService.GetAccountInfoAsync("simplemove17");
            return View();
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
