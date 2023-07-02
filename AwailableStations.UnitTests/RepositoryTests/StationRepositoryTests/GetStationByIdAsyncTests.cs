using AwailableStations.Domain.Entities;
using AwailableStations.UnitTests.RepositoryTests.FakeImplements;

namespace AwailableStations.UnitTests.RepositoryTests.StationRepositoryTests
{
	public class GetStationByIdAsyncTests
	{
		[Test]
		public async Task GetStationByIdAsync_Get_station_by_id_Return_station_with_setting_id_And_not_null_station()
		{
			// arrange
			var findId = Guid.Parse("{7B8FAB57-ABE4-43BD-815E-26873489DAA2}");
			var stringFake = "Test";
			var station = new Station
			{
				Id = findId,
				Title = stringFake,
				Direction = stringFake,
				StationType = stringFake,
				TransportType = stringFake,
				Longitude = 0,
				Latitude = 0,
				EsrCode = stringFake,
				YandexCode = stringFake
			};

			var stationRepository = new FakeStationRepository(new List<Station> { station });

			// act
			var expectedStation = await stationRepository.GetStationByIdAsync(findId);

			// assert
			Assert.NotNull(expectedStation);
			Assert.That(expectedStation, Is.EqualTo(station));
		}

		[Test]
		public async Task GetStationByIdAsync_Get_station_by_id_Return_null_station()
		{
			// arrange
			var findId = Guid.Parse("{7B8FAB57-ABE4-43BD-815E-26873489DAA2}");
			var stationRepository = new FakeStationRepository();

			// act
			var expectedStation = await stationRepository.GetStationByIdAsync(findId);

			// assert
			Assert.IsNull(expectedStation);
		}
	}
}
