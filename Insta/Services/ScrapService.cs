using System;
using Insta.Models;
using System.Threading.Tasks;
using System.Net.Http;

namespace Insta.Services
{
    public class ScrapService : IScrapService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ScrapService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task GetAccountInfoAsync(string username)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, 
             $"http://localhost/?username={username}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("ok");
            }
            else
            {
               Console.WriteLine("error");
            }          
        }
    }
}