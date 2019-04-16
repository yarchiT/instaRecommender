using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Insta.Models;
using Insta.Services;
using System.Diagnostics;

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
        [HttpGet]
        public async Task<IActionResult> GetUserPosts(string username)
        {
            var userPosts = new List<Post>();
            try{
                AccountInfo accountInfo = await _scrapService.GetAccountInfoAsync(username, 2);
                var account = await _context.AccountInfo.FirstOrDefaultAsync(x => x.Username == accountInfo.Username);

                if (account == null)
                {
                    await _context.AccountInfo.AddAsync(accountInfo);
                    await _context.SaveChangesAsync();
                }
                userPosts = account.Posts;
            }catch (Exception ex){

            }

            if (userPosts.Count == 0)
            return View("Index", "We coudn't fetch data from your profile");
            
            return View(userPosts);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
