namespace AwailableStations.Domain.Entities
{
	public class Station
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Direction { get; set; } = string.Empty;
		public string StationType { get; set; } = string.Empty;
		public string TransportType { get; set; } = string.Empty;
		public double Longitude { get; set; }
		public double Latitude { get; set; }
		public string? EsrCode { get; set; }
		public string? YandexCode { get; set; }
	}
}
