namespace AwailableStations.API.Models.RequestModels
{
	public class CreateStationRequest
	{
		public string Title { get; set; }
		public string Direction { get; set; }
		public string StationType { get; set; }
		public string TransportType { get; set; }
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public string? EsrCode { get; set; }
		public string? YandexCode { get; set; }
	}
}
