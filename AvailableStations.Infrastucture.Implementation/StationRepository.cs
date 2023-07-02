using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

using AwailableStations.Domain.Entities;
using AwailableStations.Domain.Models;
using AvailableStations.Infrastucture.Interfaces;
using AwailableStations.DataAccess.PostgreSql;
using AwailableStations.DataAccess.PostgreSql.EntitiesEF;

namespace AvailableStations.Infrastucture.Implementation
{
	public class StationRepository : IStationRepository
	{
		private readonly ApplicationDbContext _context;
		private readonly IMapper _mapper;

		public StationRepository(ApplicationDbContext context, IMapper mapper)
		{
			_context = context;
			_mapper = mapper;
		}

		public async Task<Station?> GetStationByIdAsync(Guid id)
		{
			var station = await _context.Stations
				.FindAsync(id);
			if (station != null)
			{
				return _mapper.Map<Station>(station);
			}

			return null;
		}

		public async Task<IEnumerable<Station>> GetStationsInAreaAsync(MapArea area, int limit, int offset)
		{
			var polyArea = new Polygon(new LinearRing(new[]
			{
				new Coordinate(area.Left, area.Top),
				new Coordinate(area.Right, area.Top),
				new Coordinate(area.Right, area.Bottom),
				new Coordinate(area.Left, area.Bottom),
				new Coordinate(area.Left, area.Top)
			}));

			var areaCenter = new Point(Math.Abs(area.Right) - Math.Abs(area.Left), Math.Abs(area.Top) - Math.Abs(area.Bottom));

			return await _context.Stations
				.Where(e => polyArea.Contains(e.Location))
				.OrderBy(e => e.Location.Distance(areaCenter))
				.Skip(offset)
				.Take(limit)
				.ProjectTo<Station>(_mapper.ConfigurationProvider)
				.ToListAsync();
		}

		public async Task<int> GetStationCountAsync(MapArea area)
		{
			var polyArea = new Polygon(new LinearRing(new[]
			{
				new Coordinate(area.Left, area.Top),
				new Coordinate(area.Right, area.Top),
				new Coordinate(area.Right, area.Bottom),
				new Coordinate(area.Left, area.Bottom),
				new Coordinate(area.Left, area.Top)
			}));

			return await _context.Stations
				.Where(e => polyArea.Contains(e.Location))
				.CountAsync();
		}

		public async Task<Station?> CreateAsync(Station station)
		{
			var existedStation = await _context.Stations
				.Where(e => e.Title == station.Title || (e.Location.X == station.Longitude && e.Location.Y == station.Latitude))
				.FirstOrDefaultAsync();

			if (existedStation == null)
			{
				var createdStation = _mapper.Map<StationEF>(station);
				await _context.Stations.AddAsync(createdStation);
				await _context.SaveChangesAsync();

				station = _mapper.Map<Station>(createdStation);

				return station;
			}

			return null;
		}

		public async Task<Station?> UpdateAsync(Station station)
		{
			var existingStation = await _context.Stations.FindAsync(station.Id);
			if (existingStation != null)
			{
				_mapper.Map(existingStation, station);
				await _context.SaveChangesAsync();

				return _mapper.Map<Station>(existingStation);
			}

			return null;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var existingStation = await _context.Stations.FindAsync(id);
			if (existingStation != null)
			{
				_context.Stations.Remove(existingStation);
				await _context.SaveChangesAsync();

				return true;
			}

			return false;
		}
	}
}
