using Segfy.Youtube.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq.Expressions;

namespace Segfy.Youtube.Core.Repository.MongoDb
{
    public class MongoDbYoutubeRepository : IYoutubeRepository
    {

        private readonly MongoClient client;

        private readonly IMongoDatabase db;

        private readonly IMongoCollection<Videos> videos;
        private readonly IMongoCollection<Channels> channels;

        public MongoDbYoutubeRepository(string conn)
        {
            client = new MongoClient(conn);

            db = client.GetDatabase("Segfy-Youtube");

            videos = db.GetCollection<Videos>("videos");
            channels = db.GetCollection<Channels>("channels");
        }

        public async Task<IEnumerable<Channels>> GetChannels(GetFilter filter)
        {
            var f = FilterDefinition<Channels>.Empty;

            var skip = filter.MaxResults * (filter.Page - 1);
            var limit = filter.MaxResults;

            var query = channels.Find(f).Skip(skip).Limit(limit);
            var list = await query.ToListAsync();

            return list;
        }

        public async Task<IEnumerable<Videos>> GetVideos(GetFilter filter)
        {
            var f = FilterDefinition<Videos>.Empty;

            var skip = filter.MaxResults * (filter.Page - 1);
            var limit = filter.MaxResults;

            var query = videos.Find(f).Skip(skip).Limit(limit);
            var list = await query.ToListAsync();

            return list;
        }

        public async Task SaveChannel(Channels channel)
        {
            channel.CreatedAt = DateTime.Now;

            await channels.InsertOneAsync(channel);
        }

        public async Task SaveVideo(Videos video)
        {
            video.CreatedAt = DateTime.Now;

            await videos.InsertOneAsync(video);
        }

        public async Task<bool> DeleteChannel(string channelId)
        {
            Expression<Func<Channels, bool>> filter = f => f.ChannelId == channelId;

            var result = await channels.DeleteOneAsync(filter);

            return result.DeletedCount > 0;
        }

        public async Task<bool> DeleteVideo(string videoId)
        {
            Expression<Func<Videos, bool>> filter = f => f.VideoId == videoId;

            var result = await videos.DeleteOneAsync(filter);

            return result.DeletedCount > 0;
        }

        public async Task<long> GetCountVideos()
        {
            var result = await videos.CountDocumentsAsync(FilterDefinition<Videos>.Empty);

            return result;
        }

        public async Task<long> GetCountChannels()
        {
            var result = await channels.CountDocumentsAsync(FilterDefinition<Channels>.Empty);

            return result;
        }

        public async Task<Videos> GetVideo(string videoId)
        {
            Expression<Func<Videos, bool>> filter = f => f.VideoId == videoId;

            var result = await videos.Find(filter).FirstOrDefaultAsync();

            return result;
        }

        public async Task<Channels> GetChannel(string channelId)
        {
            Expression<Func<Channels, bool>> filter = f => f.ChannelId == channelId;

            var result = await channels.Find(filter).FirstOrDefaultAsync();

            return result;
        }
    }
}
