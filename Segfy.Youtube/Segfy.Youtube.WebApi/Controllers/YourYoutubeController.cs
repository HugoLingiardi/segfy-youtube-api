using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Segfy.Youtube.Core.Models;
using Segfy.Youtube.Core.Repository;
using Segfy.Youtube.WebApi.Commom;
using Segfy.Youtube.WebApi.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Segfy.Youtube.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YourYoutubeController : ControllerBase
    {
        private readonly IYoutubeRepository repository;
        private readonly IMapper mapper;

        public YourYoutubeController(IYoutubeRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }


        [HttpGet("videos")]
        public async Task<IActionResult> GetVideos([FromQuery] YourYoutubeControllerQueryParams p)
        {
            try
            {
                var list = await repository.GetVideos(new GetFilter { Page = p.Page ?? 1, MaxResults = p.MaxResults ?? 10 });
                var r = mapper.Map<IEnumerable<VideosDto>>(list);

                var paging = new PagingResult<VideosDto>(
                                    p,
                                    Task.FromResult(r),
                                    repository.GetCountVideos());

                return paging;
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

        [HttpGet("channels")]
        public async Task<IActionResult> GetChannels([FromQuery] YourYoutubeControllerQueryParams p)
        {
            try
            {
                var list = await repository.GetChannels(new GetFilter { Page = p.Page ?? 1, MaxResults = p.MaxResults ?? 10 });
                var r = mapper.Map<IEnumerable<ChannelsDto>>(list);

                var paging = new PagingResult<ChannelsDto>(
                                    p,
                                    Task.FromResult(r),
                                    repository.GetCountChannels());

                return paging;
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }


        [HttpPost("video")]
        public async Task<IActionResult> SaveVideo([FromBody] VideosDto video)
        {
            try
            {
                await repository.SaveVideo(mapper.Map<Videos>(video));

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

        [HttpPost("channel")]
        public async Task<IActionResult> SaveChannel([FromBody] ChannelsDto channel)
        {
            try
            {
                await repository.SaveChannel(mapper.Map<Channels>(channel));

                return Ok();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

        [HttpDelete("video/{videoId}")]
        public async Task<IActionResult> DeleteVideo(string videoId)
        {
            try
            {
                var result = await repository.DeleteVideo(videoId);

                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

        [HttpDelete("channel/{channelId}")]
        public async Task<IActionResult> DeleteChannel(string channelId)
        {
            try
            {
                var result = await repository.DeleteChannel(channelId);

                if (result)
                    return Ok();
                else
                    return NotFound();
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

        [HttpGet("video/{videoId}")]
        public async Task<IActionResult> VideoExists(string videoId)
        {
            try
            {
                var result = await repository.GetVideo(videoId);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

        [HttpGet("channel/{channelId}")]
        public async Task<IActionResult> ChannelExists(string channelId)
        {
            try
            {
                var result = await repository.GetChannel(channelId);

                return new OkObjectResult(result);
            }
            catch (Exception)
            {
                return BadRequest(new { Message = "Error processing your request." });
            }
        }

    }
}
