namespace AwailableStations.API.Models.ViewModels
{
	public class StationPoints
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public double Longitude { get; set; }
		public double Latitude { get; set; }
	}
}
