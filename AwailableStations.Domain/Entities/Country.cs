namespace AwailableStations.Domain.Entities
{
	public class Country
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? YandexCode { get; set; }
	}
}
