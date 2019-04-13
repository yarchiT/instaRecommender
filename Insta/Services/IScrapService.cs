using Insta.Models;
using System.Threading.Tasks;

namespace Insta.Services
{
    public interface IScrapService
    {
        Task GetAccountInfoAsync (string username);
    }
}