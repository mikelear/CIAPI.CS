using System;
using System.Threading;
using CIAPI.DTO;
using Newtonsoft.Json;
using NUnit.Framework;
using StreamingClient;

namespace CIAPI.IntegrationTests.Streaming
{
    [TestFixture]
    public class NewsFixture:RpcFixtureBase
    {
        

        [Test]
        public void CanConsumeNewsStream()
        {
            var gate = new ManualResetEvent(false);

            var streamingClient = BuildStreamingClient();
            //streamingClient.Connect();

            var newsListener = streamingClient.BuildNewsHeadlinesListener("UK");
            //newsListener.Start();

            NewsDTO actual = null;

            //Trap the Price given by the update event for checking
            newsListener.MessageReceived += (s, e) =>
            {
                actual = e.Data;
                Console.WriteLine(actual);
                gate.Set();
            };

            bool timedOut = false;

            if (!gate.WaitOne(TimeSpan.FromSeconds(15)))
            {
                timedOut = true;
            }

            
            streamingClient.TearDownListener(newsListener);
            streamingClient.Dispose();

            Assert.IsFalse(timedOut,"timed out");
            Assert.IsNotNull(actual);
            Assert.IsNotNullOrEmpty(actual.Headline);

            Assert.Greater(actual.PublishDate, DateTime.UtcNow.AddMonths(-1));
            Assert.Greater(actual.StoryId, 0);
        }



        [Test]
        public void CanConsumeQuotesStream()
        {
            var gate = new ManualResetEvent(false);

            var streamingClient = BuildStreamingClient();
            //streamingClient.Connect();

            var newsListener = streamingClient.BuildQuotesListener();
            //newsListener.Start();

            QuoteDTO actual = null;

            //Trap the Price given by the update event for checking
            newsListener.MessageReceived += (s, e) =>
            {
                actual = e.Data;
                Console.WriteLine(actual);
                gate.Set();
            };

            bool timedOut = false;

            if (!gate.WaitOne(TimeSpan.FromSeconds(15)))
            {
                timedOut = true;
            }

            streamingClient.TearDownListener(newsListener);
            streamingClient.Dispose();
            Assert.IsFalse(timedOut, "timed out");
            Assert.IsNotNull(actual);
 
        }
    }
}
