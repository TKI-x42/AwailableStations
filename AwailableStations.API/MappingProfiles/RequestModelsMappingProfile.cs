using AutoMapper;

using AwailableStations.Domain.Entities;
using AwailableStations.API.Models.RequestModels;

namespace AwailableStations.API.MappingProfiles
{
    public class RequestModelsMappingProfile : Profile
    {
        public RequestModelsMappingProfile()
        {
			CreateMap<CreateStationRequest, Station>();
		}
    }
}
