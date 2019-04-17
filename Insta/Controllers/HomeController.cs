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
        private readonly IRecommenderService _recommenderService;
        private readonly InstaWebDbContext _context;

        public HomeController(IScrapService scrapService, InstaWebDbContext context, IRecommenderService recommenderService)
        {
            _scrapService = scrapService;
            _context = context;
            _recommenderService = recommenderService;
        }
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> GetUserPosts(string username)
        {
            AccountInfo accountInfo = null;
            try{
                accountInfo = await _scrapService.GetAccountInfoAsync(username, 20);
                if (accountInfo != null){
                    var account = await _context.AccountInfo.FirstOrDefaultAsync(x => x.Username == accountInfo.Username);

                    if (account == null)
                    {
                        await _context.AccountInfo.AddAsync(accountInfo);
                        await _context.SaveChangesAsync();
                    }
                }
                
            }catch (Exception ex){

            }

            if ( accountInfo == null || accountInfo.Posts?.Count == 0 )
                return View("Index", "We coudn't fetch data from your profile");
            
            return View("ShowPosts", accountInfo.Posts);
        }

        [HttpGet]
        public async Task<IActionResult> GetRecommendedPosts(string username)
        {
            List<Post> recommendedPosts = null;
            try{
                AccountInfo accountInfo = await _scrapService.GetAccountInfoAsync(username, 2);
                if (accountInfo != null){
                    recommendedPosts = await _recommenderService.GetRecommededPosts(_scrapService, accountInfo);
                    var account = await _context.AccountInfo.FirstOrDefaultAsync(x => x.Username == accountInfo.Username);

                    if (account == null)
                    {
                        await _context.AccountInfo.AddAsync(accountInfo);
                        await _context.SaveChangesAsync();
                    }
                }
                
            }catch (Exception ex){

            }

            if ( recommendedPosts == null || recommendedPosts?.Count == 0 )
                return View("Index", "We coudn't fetch data from your profile");
            
            return View("ShowPosts", recommendedPosts);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
