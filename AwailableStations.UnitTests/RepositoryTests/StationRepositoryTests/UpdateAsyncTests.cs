using AwailableStations.Domain.Entities;
using AwailableStations.UnitTests.RepositoryTests.FakeImplements;

namespace AwailableStations.UnitTests.RepositoryTests.StationRepositoryTests
{
	public class UpdateAsyncTests
	{
		[Test]
		public async Task UpdateAsync_Update_station_Return_updated_station_and_not_null_station()
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
			var stationToUpdate = new Station
			{
				Id = findId,
				Title = "Update field",
				Direction = "Update field",
				StationType = stringFake,
				TransportType = stringFake,
				Longitude = 0,
				Latitude = 0,
				EsrCode = stringFake,
				YandexCode = stringFake
			};
			var stationRepository = new FakeStationRepository(new List<Station> { station });

			// act
			var updatedStation = await stationRepository.UpdateAsync(stationToUpdate);

			// assert
			Assert.IsNotNull(updatedStation);
			Assert.That(updatedStation, Is.EqualTo(stationToUpdate));
		}

		[Test]
		public async Task UpdateAsync_Update_station_Return_null_station()
		{
			// arrange
			var findId = Guid.Parse("{7B8FAB57-ABE4-43BD-815E-26873489DAA2}");
			var stringFake = "Test";
			var stationToUpdate = new Station
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
			var updatedStation = await stationRepository.UpdateAsync(stationToUpdate);

			// assert
			Assert.IsNull(updatedStation);
		}
	}
}
