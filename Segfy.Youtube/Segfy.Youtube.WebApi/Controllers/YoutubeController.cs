using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Segfy.Youtube.Core.Models.YoutubeResult;
using Segfy.Youtube.Core.Provider;
using Segfy.Youtube.WebApi.Commom;

namespace Segfy.Youtube.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YoutubeController : ControllerBase
    {

        private readonly YoutubeApiProvider provider;

        public YoutubeController(YoutubeApiProvider provider)
        {
            this.provider = provider;
        }

        [HttpGet("videos")]
        public async Task<YoutubeExternalResult> GetVideos([FromQuery] YoutubeControllerQueryParams p)
        {
            var result = await provider.GetVideos(p.Search, p.PageToken);

            return result;
        }

        [HttpGet("channels")]
        public async Task<YoutubeExternalResult> GetChannels([FromQuery] YoutubeControllerQueryParams p)
        {
            var result = await provider.GetChannels(p.Search, p.PageToken);

            return result;
        }

    }
}
