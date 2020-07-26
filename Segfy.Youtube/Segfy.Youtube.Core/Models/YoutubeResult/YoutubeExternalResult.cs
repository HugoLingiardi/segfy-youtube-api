using System;
using System.Collections.Generic;
using System.Text;

namespace Segfy.Youtube.Core.Models.YoutubeResult
{
    public class YoutubeExternalResult
    {
        public string PreviousPageToken { get; set; }
        public string NextPageToken { get; set; }
        public Item[] Items { get; set; }

    }
}
