using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segfy.Youtube.WebApi.Model
{
    public class VideosDto
    {   
        public string VideoId { get; set; }        
        public string Title { get; set; }        
        public string Description { get; set; }        
        public string ChannelTitle { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
