using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Http;
using Moq;
using Segfy.Youtube.Core.Models;
using Segfy.Youtube.Core.Repository;
using Segfy.Youtube.WebApi.Commom;
using Segfy.Youtube.WebApi.Controllers;
using Segfy.Youtube.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Segfy.Youtube.Tests
{
    [Collection("YourYoutubeController")]
    public class YourYoutubeControllerTests
    {
        private readonly Mock<IYoutubeRepository> mockRepository;
        private readonly Mock<IMapper> mockMapper;

        private readonly YourYoutubeController controller;

        public YourYoutubeControllerTests()
        {
            mockRepository = new Mock<IYoutubeRepository>();
            mockMapper = new Mock<IMapper>();

            controller = new YourYoutubeController(mockRepository.Object, mockMapper.Object);
        }

        [Fact()]
        public async Task GetVideosMustReturnValuesWhenThereAreValues()
        {
            var items = GetRandomData<Videos>(3);
            var itemsDto = GetRandomData<VideosDto>(3);

            mockRepository.Setup(f => f.GetVideos(It.IsAny<GetFilter>())).ReturnsAsync(items);
            mockRepository.Setup(f => f.GetCountVideos()).ReturnsAsync(items.Count());

            mockMapper.Setup(f => f.Map<IEnumerable<VideosDto>>(items)).Returns(itemsDto);

            var o = await controller.GetVideos(new YourYoutubeControllerQueryParams { Page = 1 });

            mockRepository.Verify(f => f.GetVideos(It.IsAny<GetFilter>()), Times.Once);

            Assert.IsType<PagingResult<VideosDto>>(o);
        }

        [Fact()]
        public async Task GetChannelsMustReturnValuesWhenThereAreValues()
        {
            var items = GetRandomData<Channels>(3);
            var itemsDto = GetRandomData<ChannelsDto>(3);

            mockRepository.Setup(f => f.GetChannels(It.IsAny<GetFilter>())).ReturnsAsync(items);
            mockRepository.Setup(f => f.GetCountChannels()).ReturnsAsync(items.Count());

            mockMapper.Setup(f => f.Map<IEnumerable<ChannelsDto>>(items)).Returns(itemsDto);

            var o = await controller.GetChannels(new YourYoutubeControllerQueryParams { Page = 1 });

            mockRepository.Verify(f => f.GetChannels(It.IsAny<GetFilter>()), Times.Once);

            Assert.IsType<PagingResult<ChannelsDto>>(o);
        }

        private IEnumerable<T> GetRandomData<T>(int qty) where T : class, new()
        {
            var result = new List<T>(qty);

            for (int i = 1; i <= qty; i++)
            {
                var item = new T();

                foreach (var prop in item.GetType().GetProperties())
                {
                    if (prop.PropertyType == typeof(string))
                        prop.SetValue(item, $"teste {i}");
                    else if (prop.PropertyType == typeof(DateTime))
                        prop.SetValue(item, DateTime.Now);
                }

                result.Add(item);
            }

            return result;
        }
    }
}
