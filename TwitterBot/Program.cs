using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;

namespace TwitterBot
{
    public class Program
    {
        static HttpClient client = new HttpClient();

        public static void ExportToFile(string[] tokenArr)
        {
            File.WriteAllLines(Configurations.tokenPath, tokenArr);
        }
        static async Task Main()
        {
            Console.WriteLine($"<{DateTime.Now}> - Bot Started");
            RunAsync().GetAwaiter().GetResult();
            Console.WriteLine($"<{DateTime.Now}> - Task Bot Finished");
        }

        static async Task RunAsync()
        {

            try
            {
                string[] readText = File.ReadAllLines(Configurations.tokenPath, Encoding.UTF8);
                var accessToken = readText[0];
                var accessSecretToken = readText[1];
                

                var twitterHelper = new TwitterHelper(Configurations.apiKey, Configurations.apiKeySecret, accessToken, accessSecretToken);                

                var tweets = await twitterHelper.SearchTweetsAsync("hoy cocine");
                foreach (var tweet in tweets)
                {
                    try
                    {
                        await twitterHelper.Retweet(tweet.Id);
                        Console.WriteLine(tweet.Text);
                    }
                    catch (Exception e)
                    {

                        Console.WriteLine("Ya se retuiteo el tuit:", tweet.Id);
                    }
                    
                }
                Console.ReadLine();


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
    }
}
