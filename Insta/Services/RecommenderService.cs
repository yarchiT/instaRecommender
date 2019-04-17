using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Insta.Models;

namespace Insta.Services
{
    public class RecommenderService : IRecommenderService
    {
        private Dictionary<string,int> allHashtags;
        private Dictionary<string,int> topLocationCountries;
        public async Task<List<Post>> GetRecommededPosts(IScrapService scrapService, AccountInfo user)
        {
            var recommendedPosts = new List<Post>(); 
            InitTopLocationHashtagPosts(user.Posts);
            var topHashtagList = new List<string>();

            if (allHashtags.Count > 0)
            {
                var allHashtagsList = allHashtags.ToList(); 
                allHashtagsList.Sort((ht1,ht2) => ht1.Value.CompareTo(ht2.Value));
                topHashtagList.AddRange(allHashtagsList.Select(kv => kv.Key).ToList().Take(5));
            }
           
           foreach (var hashtag in topHashtagList)
           {
               recommendedPosts.AddRange(await scrapService.GetHashtagPosts(hashtag));
           }


           return recommendedPosts;
        }

        private void InitTopLocationHashtagPosts(List<Post> posts)
        {
            allHashtags = new Dictionary<string, int>();
            topLocationCountries = new Dictionary<string, int>();

            foreach (var post in posts)
            {
                foreach (var hashtag in post.HashTags)
                {
                    if(allHashtags.ContainsKey(hashtag))
                        allHashtags[hashtag] += 1;
                    else
                        allHashtags[hashtag] = 1;
                }

                if(allHashtags.ContainsKey(post.LocationCountry))
                    allHashtags[post.LocationCountry] += 1;
                else
                    allHashtags[post.LocationCountry] = 1;
            }

        }

    }
}