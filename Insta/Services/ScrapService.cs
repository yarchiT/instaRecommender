using System;
using Insta.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;

namespace Insta.Services
{
    public class ScrapService : IScrapService
    {
        private readonly IHttpClientFactory _clientFactory;

        public ScrapService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<AccountInfo> GetAccountInfoAsync(string username, int numOfPosts)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, 
                $"http://localhost/?username={username}&postNum={numOfPosts}");

                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonStringResponse = await response.Content.ReadAsStringAsync();
                    AccountInfo accountInfo = JsonConvert.DeserializeObject<AccountInfo>(jsonStringResponse);
                    return accountInfo;
                }
                else
                {
                    throw new Exception("Didn't parse");
                }         

            } catch (Exception ex)
            {
                Console.WriteLine("error");
            }
            
            return null;
            
        }
    }
}