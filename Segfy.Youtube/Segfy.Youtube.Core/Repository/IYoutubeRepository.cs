using Segfy.Youtube.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Segfy.Youtube.Core.Repository
{
    public interface IYoutubeRepository
    {
        Task<IEnumerable<Videos>> GetVideos(GetFilter filter);
        Task<IEnumerable<Channels>> GetChannels(GetFilter filter);

        Task<long> GetCountVideos();
        Task<long> GetCountChannels();

        Task SaveVideo(Videos video);
        Task SaveChannel(Channels channel);

        Task<bool> DeleteVideo(string videoId);
        Task<bool> DeleteChannel(string channelId);

        Task<Videos> GetVideo(string videoId);
        Task<Channels> GetChannel(string channelId);
    }
}
