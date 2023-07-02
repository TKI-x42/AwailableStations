namespace AwailableStations.DataAccess.PostgreSql.EntitiesEF
{
	public class SettlementEF
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? YandexCode { get; set; }

		public Guid? RegionId { get; set; }
		public RegionEF? Region { get; set; }

		public List<StationEF> Stations { get; set; } = new();
	}
}
