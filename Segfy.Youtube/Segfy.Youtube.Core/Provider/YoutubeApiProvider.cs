using Segfy.Youtube.Core.Models.YoutubeResult;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Flurl;
using Flurl.Http;

namespace Segfy.Youtube.Core.Provider
{
    public class YoutubeApiProvider
    {

        private const int YOUTUBE_MAX_RESULTS = 5;
        private const string YOUTUBE_API = "https://www.googleapis.com/youtube/v3/search";

        private readonly string apiKey;

        public YoutubeApiProvider(string apiKey)
        {
            this.apiKey = apiKey;
        }

        public async Task<YoutubeExternalResult> GetVideos(string search, string pageToken)
        {
            var result = await GetBaseResult("video", search, pageToken);

            return result;
        }

        public async Task<YoutubeExternalResult> GetChannels(string search, string pageToken)
        {
            var result = await GetBaseResult("channel", search, pageToken);

            return result;
        }

        private async Task<YoutubeExternalResult> GetBaseResult(string type, string search, string pageToken)
        {
            var url = YOUTUBE_API.SetQueryParams(GetDefaultQueryParams(type, search, pageToken));

            var result = await url.GetJsonAsync<YoutubeResult>();

            return new YoutubeExternalResult { NextPageToken = result.nextPageToken, PreviousPageToken = result.prevPageToken, Items = result.items };
        }

        private object GetDefaultQueryParams(string type, string search, string pageToken)
        {
            return new
            {
                part = "snippet",
                type,
                pageToken,
                q = search,
                key = apiKey,
                maxResults = YOUTUBE_MAX_RESULTS,
            };
        }

    }
}
