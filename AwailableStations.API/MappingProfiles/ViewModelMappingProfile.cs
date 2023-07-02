using AutoMapper;

using AwailableStations.Domain.Entities;
using AwailableStations.API.Models.ViewModels;

namespace AwailableStations.API.MappingProfiles
{
    public class ViewModelMappingProfile : Profile
    {
        public ViewModelMappingProfile()
        {
            CreateMap<Station, StationPoints>();
        }
    }
}
