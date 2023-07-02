namespace AwailableStations.Domain.Entities
{
	public class Region
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? YandexCode { get; set; }
	}
}
