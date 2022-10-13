using System.Configuration;

namespace TwitterBot
{
    public class Configurations
    {
        public static string apiKey = ConfigurationManager.AppSettings["apiKey"];
        public static string apiKeySecret = ConfigurationManager.AppSettings["apiKeySecret"];
        public static string accessToken = ConfigurationManager.AppSettings["accessToken"];
        public static string accessSecretToken = ConfigurationManager.AppSettings["accessSecretToken"];
        public static string BearerToken = ConfigurationManager.AppSettings["BearerToken"];
        public static string requestTokenUrl = ConfigurationManager.AppSettings["requestTokenUrl"];
        public static string authorizeTokenUrl = ConfigurationManager.AppSettings["authorizeTokenUrl"];
        public static string callBackUrl = ConfigurationManager.AppSettings["callBackUrl"];
        public static string tokenPath = ConfigurationManager.AppSettings["tokenPath"];
    }
}
