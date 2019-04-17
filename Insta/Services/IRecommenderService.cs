using System;
using System.Collections.Generic;
using Insta.Models;
using System.Threading.Tasks;

namespace Insta.Services
{
    public interface IRecommenderService
    {
        Task<List<Post>> GetRecommededPosts(IScrapService scrapService, AccountInfo user);
    }
       
}