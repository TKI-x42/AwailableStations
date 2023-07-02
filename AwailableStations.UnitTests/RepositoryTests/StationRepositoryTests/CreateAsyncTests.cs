using AwailableStations.Domain.Entities;
using AwailableStations.UnitTests.RepositoryTests.FakeImplements;

namespace AwailableStations.UnitTests.RepositoryTests.StationRepositoryTests
{
	public class CreateAsyncTests
	{
		[Test]
		public async Task CreateAsync_Create_station_Return_craeted_station_and_not_null_station()
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
			var stationRepository = new FakeStationRepository();

			// act
			var createdStation = await stationRepository.CreateAsync(station);

			// assert
			Assert.IsNotNull(createdStation);
			Assert.That(createdStation, Is.EqualTo(station));
		}

		[Test]
		public async Task CreateAsync_Create_station_Return_null_station()
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
			var addedStation = new Station
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
			var createdStation = await stationRepository.CreateAsync(addedStation);

			// assert
			Assert.IsNull(createdStation);
		}
	}
}
