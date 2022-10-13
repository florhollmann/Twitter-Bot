using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Models;
using Tweetinvi.Parameters;
using Tweetinvi.Parameters.Enum;

namespace TwitterBot
{
    public class TwitterHelper
    {
        private TwitterClient _twitterClient { get; set; }
        public TwitterHelper(string apiKey, string apiSecret, string accessToken, string accessSecret)
        {
            _twitterClient = new TwitterClient(apiKey, apiSecret, accessToken, accessSecret);
        }

        public ISearchTweetsParameters BuildParameters(string query)
        {
            var searchParameter = new SearchTweetsParameters(query)
            {
                //GeoCode = new GeoCode(-19.439783, -58.409370, 5000, DistanceMeasure.Kilometers),
                Lang = LanguageFilter.Spanish,
                SearchType = SearchResultType.Recent,
                Since = DateTime.Today.AddDays(-1),
                Until = DateTime.Today
                //Filters = TweetSearchFilters.
            };

            return searchParameter;
        }

        public async Task<ITweet[]> SearchTweetsAsync(string query)
        {
            if (_twitterClient == null)
                return null;

            try
            {
                var searchParam = BuildParameters(query);
                return await _twitterClient.Search.SearchTweetsAsync(searchParam);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }


        public async Task<ITweet[]> SearchTweetsAsync(ISearchTweetsParameters parameters)
        {
            if (_twitterClient == null)
                return null;

            try
            {
                return await _twitterClient.Search.SearchTweetsAsync(parameters);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task Post(string tweet)
        { 
            try
            {
                Console.WriteLine(tweet);
                await _twitterClient.Tweets.PublishTweetAsync(tweet);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public async Task Retweet(long id)
        {
            try
            {
                Console.WriteLine(id);
                await _twitterClient.Tweets.PublishRetweetAsync(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
