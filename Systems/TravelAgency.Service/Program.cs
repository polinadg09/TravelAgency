using TravelAgency.Service.Configuration;

var builder = WebApplication.CreateBuilder(args);

// ----------------------------

var services = builder.Services;

// Configure DB
var connectionString = builder.Configuration.GetConnectionString("TravelAgencyDbContext");

services.AddDataBase(connectionString ?? "");

services.AddControllers();
services.AddOpenApi();

// ----------------------------

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();

app.MapControllers();

app.UseDataBase();

app.Run();
