using System.Collections.Generic;
using System.Threading.Tasks;
using Insta.Models;

namespace Insta.Services
{
    public class RecommenderService : IRecommenderService
    {
        private Dictionary<string,int> topHashtags;
        private Dictionary<string,int> topLocationCountries;
        public Task<List<Post>> GetRecommededPosts(IScrapService scrapService, AccountInfo user)
        {
           InitTopLocationHashtagPosts(user.Posts);

           return null;
        }

        private void InitTopLocationHashtagPosts(List<Post> posts)
        {
            topHashtags = new Dictionary<string, int>();
            topLocationCountries = new Dictionary<string, int>();

            foreach (var post in posts)
            {
                foreach (var hashtag in post.HashTags)
                {
                    if(topHashtags.ContainsKey(hashtag))
                        topHashtags[hashtag] += 1;
                    else
                        topHashtags[hashtag] = 1;
                }

                if(topHashtags.ContainsKey(post.LocationCountry))
                    topHashtags[post.LocationCountry] += 1;
                else
                    topHashtags[post.LocationCountry] = 1;
            }

        }

    }
}