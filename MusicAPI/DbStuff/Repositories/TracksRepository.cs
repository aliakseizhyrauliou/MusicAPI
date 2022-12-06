using Microsoft.EntityFrameworkCore;
using MusicAPI.DbStuff.DbModels;
using MusicAPI.DbStuff.Repositories.IRepositories;

namespace MusicAPI.DbStuff.Repositories
{
    public class TracksRepository : ITracksRepository
    {
        private readonly WebContext webContext;
        public TracksRepository(WebContext context)
        {
            webContext = context;

        }

        public async Task<IEnumerable<TrackModel>> GetAllAsync()
        {
            return await webContext.Tracks.ToListAsync();
        }

        public async Task<IEnumerable<TrackModel>> GetRangeAsync(int startIndex, int endIndex)
        {
            return await webContext.Tracks
                .Skip(startIndex)
                .Take(endIndex)
                .ToListAsync();
        }
    }
}
