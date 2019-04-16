using Insta.Models;
using System.Threading.Tasks;

namespace Insta.Services
{
    public interface IScrapService
    {
        Task<AccountInfo> GetAccountInfoAsync (string username, int numOfPosts);
    }
}