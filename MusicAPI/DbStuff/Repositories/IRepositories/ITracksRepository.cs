using MusicAPI.DbStuff.DbModels;

namespace MusicAPI.DbStuff.Repositories.IRepositories
{
    public interface ITracksRepository
    {
        public Task<IEnumerable<TrackModel>> GetAllAsync();
        public Task<IEnumerable<TrackModel>> GetRangeAsync(int startIndex, int endIndex);
    }
}
