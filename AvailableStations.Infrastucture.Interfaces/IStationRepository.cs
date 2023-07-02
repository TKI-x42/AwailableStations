using AwailableStations.Domain.Entities;
using AwailableStations.Domain.Models;

namespace AvailableStations.Infrastucture.Interfaces
{
	public interface IStationRepository: IRepositoryBase<Station>
	{
		Task<IEnumerable<Station>> GetStationsInAreaAsync(MapArea area, int limit, int offcet);
		Task<Station?> GetStationByIdAsync(Guid id);
		Task<int> GetStationCountAsync(MapArea area);
	}
}
