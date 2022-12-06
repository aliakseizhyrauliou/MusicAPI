using AutoMapper;
using MusicAPI.DbStuff.DbModels;
using MusicAPI.ViewModels;

namespace MusicAPI
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<TrackModel, TrackViewModel>()
                    .ReverseMap();
            });

            return mappingConfig;
        }
    }
}
