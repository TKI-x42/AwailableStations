namespace AwailableStations.Domain.Entities
{
	public class Settlement
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? YandexCode { get; set; }
	}
}
