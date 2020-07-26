using AutoMapper;
using Segfy.Youtube.Core.Models;
using Segfy.Youtube.WebApi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Segfy.Youtube.WebApi.Commom
{
    public class YourYoutubeAutoMapperProfile : Profile
    {

        public YourYoutubeAutoMapperProfile()
        {
            CreateMap<Channels, ChannelsDto>(MemberList.Destination);
            CreateMap<Videos, VideosDto>(MemberList.Destination);

            CreateMap<ChannelsDto, Channels>(MemberList.Source);
            CreateMap<VideosDto, Videos>(MemberList.Source);
        }
    }
}
