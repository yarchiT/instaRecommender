using System;
using Insta.Models;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Insta.Services
{
    public class ScrapService : IScrapService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly string BASE_URL = "http://web:5000";

        public ScrapService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public async Task<AccountInfo> GetAccountInfoAsync(string username, int numOfPosts)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, 
                $"{BASE_URL}/?username={username}&postNum={numOfPosts}");

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

        public async Task<List<Post>> GetHashtagPosts(string hashtag)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, 
                    $"{BASE_URL}/getTopHashtagPosts?hashtag={hashtag}");

                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonStringResponse = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<Post>>(jsonStringResponse);
                    return posts;
                }
                else
                {
                    throw new Exception("Didn't parse hashtag posts properly");
                }         

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return null;
        }

        public async Task<List<Post>> GetTopLocationPosts(string locationId)
        {
            try
            {
                var request = new HttpRequestMessage(HttpMethod.Get, 
                    $"{BASE_URL}/getTopLocationPosts?locationId={locationId}");

                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var jsonStringResponse = await response.Content.ReadAsStringAsync();
                    var posts = JsonConvert.DeserializeObject<List<Post>>(jsonStringResponse);
                    return posts;
                }
                else
                {
                    throw new Exception("Didn't parse locations properly");
                }         

            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            return null;
        }
    }
}