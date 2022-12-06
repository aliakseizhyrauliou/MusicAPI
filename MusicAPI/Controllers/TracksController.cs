using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MusicAPI.DbStuff.Repositories.IRepositories;
using MusicAPI.ViewModels;

namespace MusicAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TracksController : ControllerBase
    {
        private readonly ITracksRepository _tracksRepository;
        private readonly IMapper _mapper;
        public TracksController(ITracksRepository repository,
            IMapper mapper)
        {
            _tracksRepository = repository;
            _mapper = mapper;   
        }

        [HttpGet]
        public async Task<IActionResult> GetTracks(int startIndex = 0, int endIndex = 0) 
        {
            int subsidiaryVariable;
            if (startIndex == 0 && endIndex == 0)
            {
                return Ok(_mapper.Map<IEnumerable<TrackViewModel>>(await _tracksRepository.GetAllAsync()));
            }
            else if (endIndex < startIndex) 
            {
                subsidiaryVariable = endIndex;
                endIndex = startIndex;
                startIndex = subsidiaryVariable;

                var result = await _tracksRepository.GetRangeAsync(startIndex, endIndex);
                return Ok(_mapper.Map<IEnumerable<TrackViewModel>>(result.Reverse()));
            }
            return Ok(_mapper.Map<IEnumerable<TrackViewModel>>(await _tracksRepository.GetRangeAsync(startIndex, endIndex)));
        }

    };
}