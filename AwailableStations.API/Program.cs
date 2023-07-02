using AwailableStations.API;
using AwailableStations.API.MappingProfiles;
using AwailableStations.DataAccess.PostgreSql;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Automapper
builder.Services.AddAutoMapper(typeof(PostgresMapperProfile), typeof(ViewModelMappingProfile), typeof(RequestModelsMappingProfile));

// Add Database context
builder.Services.AddPostgresDb(builder.Configuration);

// Add repositories of entities
builder.Services.AddRepositories();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseDeveloperExceptionPage();
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
