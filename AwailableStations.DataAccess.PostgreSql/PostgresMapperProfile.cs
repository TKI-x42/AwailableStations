using AutoMapper;
using NetTopologySuite.Geometries;

using AwailableStations.Domain.Entities;
using AwailableStations.DataAccess.PostgreSql.EntitiesEF;

namespace AwailableStations.DataAccess.PostgreSql
{
	public class PostgresMapperProfile : Profile
	{
		public PostgresMapperProfile()
		{
			CreateMap<StationEF, Station>()
				.ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.Location.X))
				.ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.Location.Y));

			CreateMap<Station, StationEF>()
				.ForMember(dest => dest.Id, opt => opt.MapFrom(src => Guid.NewGuid()))
				.ForMember(dest => dest.Location, opt => opt.MapFrom(src => new Point(src.Longitude, src.Latitude)));
		}
	}
}
