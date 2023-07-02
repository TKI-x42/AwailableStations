using AwailableStations.Domain.Entities;
using AwailableStations.Domain.Models;
using AvailableStations.Infrastucture.Interfaces;

namespace AwailableStations.UnitTests.RepositoryTests.FakeImplements
{
	public class FakeStationRepository : IStationRepository
	{
		private readonly List<Station> _stations;

		public FakeStationRepository() => _stations = new List<Station>();

		public FakeStationRepository(List<Station> data) => _stations = data;

		public Task<Station?> GetStationByIdAsync(Guid id)
		{
			var stations = _stations.Where(e => e.Id == id).FirstOrDefault();
			if(stations != null)
			{
				return Task.FromResult<Station?>(stations);
			}

			return Task.FromResult<Station?>(null);
		}

		public Task<IEnumerable<Station>> GetStationsInAreaAsync(MapArea area)
		{
			var stationsInArea = _stations
				.Where(e => e.Longitude > area.Left && e.Longitude < area.Right && e.Latitude > area.Bottom && e.Latitude < area.Top)
				.ToList();

			return Task.FromResult<IEnumerable<Station>>(stationsInArea);
		}

		public Task<Station?> CreateAsync(Station entity)
		{
			var existingStation = _stations
				.Where(e => e.Title == entity.Title
						&& e.Longitude == entity.Longitude && e.Latitude == entity.Latitude)
				.FirstOrDefault();

			if (existingStation == null)
			{
				_stations.Add(entity);
				return Task.FromResult<Station?>(entity);
			}

			return Task.FromResult<Station?>(null);
		}

		public Task<Station?> UpdateAsync(Station entity)
		{
			var existingStation = _stations.Find(e => e.Id == entity.Id);
			if (existingStation != null)
			{
				existingStation = entity;
				return Task.FromResult<Station?>(existingStation);
			}

			return Task.FromResult<Station?>(null);
		}

		public Task<bool> DeleteAsync(Guid id)
		{
			var existingStation = _stations.Find(e => e.Id == id);
			if (existingStation != null)
			{
				_stations.Remove(existingStation);
				return Task.FromResult(true);
			}

			return Task.FromResult(false);
		}

		public Task<IEnumerable<Station>> GetStationsInAreaAsync(MapArea area, int limit, int offcet)
		{
			throw new NotImplementedException();
		}

		public Task<int> GetStationCountAsync(MapArea area)
		{
			throw new NotImplementedException();
		}
	}
}
