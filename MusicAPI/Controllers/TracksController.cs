using Microsoft.AspNetCore.Mvc;
using MusicAPI.DbStuff.Repositories.IRepositories;

namespace MusicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly ITracksRepository _tracksRepository;
        public TracksController(ITracksRepository repository)
        {
            _tracksRepository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTracks(int startIndex = 0, int endIndex = 0) 
        {
            int subsidiaryVariable;
            if (startIndex == 0 && endIndex == 0)
            {
                return Ok(await _tracksRepository.GetAllAsync());
            }
            else if (endIndex < startIndex) 
            {
                subsidiaryVariable = endIndex;
                endIndex = startIndex;
                startIndex = subsidiaryVariable;

                var result = await _tracksRepository.GetRangeAsync(startIndex, endIndex);
                return Ok(result.Reverse());
            }
            return Ok(await _tracksRepository.GetRangeAsync(startIndex, endIndex));
        }

    };
}