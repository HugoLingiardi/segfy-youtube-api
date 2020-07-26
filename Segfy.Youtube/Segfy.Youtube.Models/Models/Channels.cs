using System;
using System.Collections.Generic;
using System.Text;

namespace Segfy.Youtube.Models.Models
{
    public class Channels
    {
        public string ChannelId { get; set; }
        public string ChannelTitle { get; set; }
        public string ChannelDescription { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
