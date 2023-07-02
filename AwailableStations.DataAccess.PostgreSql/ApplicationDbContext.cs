using Microsoft.EntityFrameworkCore;

using AwailableStations.DataAccess.PostgreSql.EntitiesEF;

namespace AwailableStations.DataAccess.PostgreSql
{
	public class ApplicationDbContext : DbContext
	{
		public DbSet<StationEF> Stations { get; set; } = null!;
		public DbSet<SettlementEF> Settlements { get; set; }
		public DbSet<RegionEF> Regions { get; set; }
		public DbSet<CountryEF> Countries { get; set; }

		public ApplicationDbContext() { }

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
