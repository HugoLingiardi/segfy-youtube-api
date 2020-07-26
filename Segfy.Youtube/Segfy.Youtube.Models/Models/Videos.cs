using System;
using System.Collections.Generic;
using System.Text;

namespace Segfy.Youtube.Models.Models
{
    public class Videos
    {
        public string VideoId { get; set; }
        public string VideoTitle { get; set; }
        public string VideoDescription { get; set; }
        public string ChannelTitle { get; set; }
        public string ThumbnailUrl { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
