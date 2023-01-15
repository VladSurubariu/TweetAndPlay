﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tweetinvi;
using Tweetinvi.Client;
using Tweetinvi.Models;

namespace ClassLibrary_TwitterAPIClient
{
    public class TwitterAPIConnection
    {
        private static string consumer_key { get; }
        private static string consumer_key_secret { get; }
        private static string acces_token { get; }
        private static string acces_token_secret { get; }
        public int numberOfTweets { get; set; }

        public TwitterClient userClient;

        public List<ITweet> timelineTweets = new List<ITweet>();

        internal static string username = "vladsrb11";

        public TwitterAPIConnection(string consumer_key, string consumer_key_secret, string acces_token, string acces_token_secret)
        {
            userClient = new TwitterClient(consumer_key, consumer_key_secret, acces_token, acces_token_secret);
        }
        
    }
    public class TwitterAPIRetrieveData : TwitterAPIConnection // mostenire
    {
        public TwitterAPIRetrieveData(string consumer_key, string consumer_key_secret, string acces_token, string acces_token_secret)
            : base(consumer_key, consumer_key_secret, acces_token, acces_token_secret)
        {
        }

        public async Task RetrieveTweets()
        {
            var timelineIterator = userClient.Timelines.GetUserTimelineIterator(username);

            while (!timelineIterator.Completed)
            {
                var page = await timelineIterator.NextPageAsync();
                timelineTweets.AddRange(page);
                numberOfTweets = Math.Max(page.Count(), numberOfTweets);
            }
        }

    }
}
