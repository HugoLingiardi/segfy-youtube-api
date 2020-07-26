using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segfy.Youtube.WebApi.Commom
{
    public class YourYoutubeControllerQueryParams : IPagingQueryParams
    {
        public int? Page { get; set; }
        public int? MaxResults { get; set; }
    }
}
