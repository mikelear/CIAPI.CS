using System;
using System.Collections.Generic;
using System.Diagnostics;
using NewsWaveRider.Core.ViewModels;
using TweetSharp;

namespace NewsWaveRider.Core
{
    public class TwitterNewsRepository : INewsRepository
    {
        public List<NewsEvent> GetNews(List<string> symbols)
        {
            var newsEvents = new List<NewsEvent>();


TwitterService service = new TwitterService();
IEnumerable<TwitterStatus> tweets = service.ListTweetsOnPublicTimeline();
foreach (var tweet in tweets)
{
    Console.WriteLine("{0} says '{1}'", tweet.User.ScreenName, tweet.Text);
}

            // Pass your credentials to the service
//            TwitterService service = new TwitterService("3er4ygyHdy6Ktzlz1Uapw", "IzteWz9rAN4IzJ1lOWhE1OGhb6pPEAealwo7ZcqLIk");
//
            // Step 1 - Retrieve an OAuth Request Token
//            OAuthRequestToken requestToken = service.GetRequestToken();
//
            // Step 2 - Redirect to the OAuth Authorization URL
//            Uri uri = service.GetAuthorizationUri(requestToken);
//            Process.Start(uri.ToString());
//
            // Step 3 - Exchange the Request Token for an Access Token
//            string verifier = "123456"; // <-- This is input into your application by your user
//            OAuthAccessToken access = service.GetAccessToken(requestToken, verifier);
//
            // Step 4 - User authenticates using the Access Token
//            service.AuthenticateWith(access.Token, access.TokenSecret);
//            IEnumerable<TwitterStatus> mentions = service.ListTweetsMentioningMe();

            return newsEvents;
        }
    }
}