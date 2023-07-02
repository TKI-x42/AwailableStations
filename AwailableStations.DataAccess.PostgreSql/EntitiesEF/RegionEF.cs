namespace AwailableStations.DataAccess.PostgreSql.EntitiesEF
{
	public class RegionEF
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string? YandexCode { get; set; }

		public Guid? CountryId { get; set; }
		public CountryEF? Country { get; set; }

		public List<SettlementEF> Settlements { get; set; } = new();
	}
}
