using AwailableStations.Domain.Entities;
using AwailableStations.Domain.Models;
using AwailableStations.UnitTests.RepositoryTests.FakeImplements;

namespace AwailableStations.UnitTests.RepositoryTests.StationRepositoryTests
{
    public class GetStationsInAreaAsyncTests
    {
		[Test]
        public async Task GetStationsInAreaAsync_Stations_within_longtitude_between10_20_And_latitude_between10_20_Return_station_collection_with_count5()
        {
            // arrange
            var data = new List<Station>();
            var trueIds = new List<Guid>();
            for (int i = 0; i < 5; i++)
            {
                var id = Guid.NewGuid();
                trueIds.Add(id);

                data.Add(new Station
                {
                    Id = id,
                    Title = $"Test{i}",
                    Direction = $"Test{i}",
                    StationType = $"Test{i}",
                    TransportType = $"Test{i}",
                    Longitude = 12 + i,
                    Latitude = 14 + i,
                    EsrCode = $"Test{i}",
                    YandexCode = $"Test{i}"
                });
            }

            var stationRepository = new FakeStationRepository(data);

            // act
            var stationCollection = await stationRepository.GetStationsInAreaAsync(new MapArea { Left = 10, Top = 20, Right = 20, Bottom = 10 });

            // assert
            Assert.That(stationCollection.Count(), Is.EqualTo(5));
            Assert.IsTrue(stationCollection.All(e => trueIds.Contains(e.Id)));
        }

		[Test]
		public async Task GetStationsInAreaAsync_Stations_without_longtitude_between10_20_And_latitude_between10_20_Return_station_collection_with_count0()
		{
			// arrange
			var data = new List<Station>();
			var trueIds = new List<Guid>();
			for (int i = 0; i < 5; i++)
			{
				var id = Guid.NewGuid();
				trueIds.Add(id);

				data.Add(new Station
				{
					Id = id,
					Title = $"Test{i}",
					Direction = $"Test{i}",
					StationType = $"Test{i}",
					TransportType = $"Test{i}",
					Longitude = 12 + i,
					Latitude = 14 + i,
					EsrCode = $"Test{i}",
					YandexCode = $"Test{i}"
				});
			}

			var stationRepository = new FakeStationRepository(data);

			// act
			var stationCollection = await stationRepository.GetStationsInAreaAsync(new MapArea { Left = -10, Top = 10, Right = 10, Bottom = -10 });

			// assert
			Assert.That(stationCollection.Count(), Is.EqualTo(0));
		}
	}
}
