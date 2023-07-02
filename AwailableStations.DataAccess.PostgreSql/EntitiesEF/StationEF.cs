using NetTopologySuite.Geometries;

namespace AwailableStations.DataAccess.PostgreSql.EntitiesEF
{
	public class StationEF
	{
		public Guid Id { get; set; }
		public string Title { get; set; } = string.Empty;
		public string Direction { get; set; } = string.Empty;
		public string StationType { get; set; } = string.Empty;
		public string TransportType { get; set; } = string.Empty;
		public Point Location { get; set; } = new Point(new Coordinate(0, 0));
		public string? EsrCode { get; set; }
		public string? YandexCode { get; set; }

		public Guid? SettlementId { get; set; }
		public SettlementEF? Settlement { get; set; }
	}
}
