using Insta.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace Insta.Services
{
    public interface IScrapService
    {
        Task<AccountInfo> GetAccountInfoAsync (string username, int numOfPosts);
        Task<List<Post>> GetTopLocationPosts(int locationId);
        Task<List<Post>> GetHashtagPosts(string hashtag);
    }
}