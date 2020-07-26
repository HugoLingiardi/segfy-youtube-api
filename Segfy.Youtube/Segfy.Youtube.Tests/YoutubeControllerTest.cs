using Xunit;
using Segfy.Youtube.WebApi.Controllers;
using Segfy.Youtube.Core.Provider;
using System.Threading.Tasks;
using Segfy.Youtube.WebApi.Commom;
using Segfy.Youtube.Tests.Properties;

namespace Segfy.Youtube.Tests
{
    [Collection("YoutubeController")]
    public class YoutubeControllerTest
    {

        private readonly YoutubeApiProvider provider;
        private readonly YoutubeController controller;

        public YoutubeControllerTest()
        {
            provider = new YoutubeApiProvider(Resources.YoutubeApiKey);
            controller = new YoutubeController(provider);
        }

        [Fact]
        public async Task ExistingVideosMustBeReturnedFromGetVideos()
        {
            var result = await controller.GetVideos(new YoutubeControllerQueryParams { Search = "shakira" });

            Assert.NotNull(result);
            Assert.NotEmpty(result.Items);
        }

        [Fact]
        public async Task ExistingChannelsMustBeReturnedFromGetChannels()
        {
            var result = await controller.GetChannels(new YoutubeControllerQueryParams { Search = "shakira" });

            Assert.NotNull(result);
            Assert.NotEmpty(result.Items);
        }

        [Fact]
        public async Task NotExistingVideosMustBeReturnGetVideos()
        {
            var result = await controller.GetVideos(new YoutubeControllerQueryParams { Search = "21312456897845123189484" });

            Assert.NotNull(result);
            Assert.Empty(result.Items);
        }

        [Fact]
        public async Task NotExistingChannelsMustBeReturnGetChannels()
        {
            var result = await controller.GetChannels(new YoutubeControllerQueryParams { Search = "21312456897845123189484" });

            Assert.NotNull(result);
            Assert.Empty(result.Items);
        }

    }
}
