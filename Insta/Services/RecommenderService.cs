using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insta.Models;

namespace Insta.Services
{
    public class RecommenderService : IRecommenderService
    {
        private Dictionary<string,int> allHashtags;
        private Dictionary<LocationDto,int> topLocationCountries;
        public async Task<List<Post>> GetRecommededPosts(IScrapService scrapService, AccountInfo user)
        {
            var recommendedPosts = new List<Post>(); 
            InitTopLocationHashtagPosts(user.Posts);
            recommendedPosts.AddRange(await GetTopLocationPosts(scrapService));
            recommendedPosts.AddRange(await GetTopHashtagPosts(scrapService));
            
           return recommendedPosts;
        }

        private async Task<IEnumerable<Post>> GetTopLocationPosts(IScrapService scrapService)
        {
            var topCountriesList = new List<LocationDto>();
            var topLocationPostsList = new List<Post>();
            if (topLocationCountries.Count > 0)
            {
                var allCountriesList = topLocationCountries.ToList(); 
                allCountriesList.Sort((ht1,ht2) => ht1.Value.CompareTo(ht2.Value));
                topCountriesList.AddRange(allCountriesList.Select(kv => kv.Key).ToList().Take(3));
            }
           
           foreach (var locationDto in topCountriesList)
           {
               if (locationDto.locationId != "")
               topLocationPostsList.AddRange(await scrapService.GetTopLocationPosts(locationDto.locationId));
           }

           return topLocationPostsList;
        }

        private async Task<IEnumerable<Post>> GetTopHashtagPosts(IScrapService scrapService)
        {
            var topHashtagList = new List<string>();
            var topHashtagPostsList = new List<Post>();
            if (topLocationCountries.Count > 0)
            {
                var allCountriesList = allHashtags.ToList(); 
                allCountriesList.Sort((ht1,ht2) => ht1.Value.CompareTo(ht2.Value));
                topHashtagList.AddRange(allCountriesList.Select(kv => kv.Key).ToList().Take(5));
            }
           
           foreach (var hashtag in topHashtagList)
           {
               if (hashtag != null || hashtag != "")
                    topHashtagPostsList.AddRange(await scrapService.GetHashtagPosts(hashtag));
           }

           return topHashtagPostsList;
        }

        private void InitTopLocationHashtagPosts(List<Post> posts)
        {
            allHashtags = new Dictionary<string, int>();
            topLocationCountries = new Dictionary<LocationDto, int>();

            foreach (var post in posts)
            {
                foreach (var hashtag in post.HashTags)
                {
                    if(allHashtags.ContainsKey(hashtag))
                        allHashtags[hashtag] += 1;
                    else
                        allHashtags[hashtag] = 1;
                }

                if (post.LocationCountry == null || post.LocationCountry == "" || post.LocationId == null || post.LocationId == "")
                    continue;
                    
                LocationDto locationDto = new LocationDto
                {
                    countryName = post.LocationCountry,
                    locationId = post.LocationId
                };

                if(topLocationCountries.ContainsKey(locationDto))
                    topLocationCountries[locationDto] += 1;
                else
                {   
                    topLocationCountries[locationDto] = 1;
                }
                    
            }

        }

        private struct LocationDto{
            public string countryName { get; set;}
            public string locationId { get; set;}
        }

    }
}