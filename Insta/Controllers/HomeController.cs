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
        private readonly InstaWebDbContext _context;

        public HomeController(IScrapService scrapService, InstaWebDbContext context)
        {
            _scrapService = scrapService;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
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
