using Microsoft.EntityFrameworkCore;
using WebApi.DAL;
using Database;
using WebApi.Seeding;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<DatabaseContext>(opt =>
    opt.UseInMemoryDatabase("Database"));
builder.Services.AddDbContext<DatabaseHistorieContext>(opt =>
    opt.UseInMemoryDatabase("DatabaseHistorie"));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<VermittlerRepository>();
builder.Services.AddScoped<AdressenRepository>();
builder.Services.AddScoped<HistorieRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
using var scope = app.Services.CreateScope();
//DB SEEDING
var databaseContext = scope.ServiceProvider.GetRequiredService<DatabaseContext>();
SeedData.InitializeDatabaseContext(databaseContext);
var databaseHistorieContext = scope.ServiceProvider.GetRequiredService<DatabaseHistorieContext>();
SeedData.InitializeDatabaseContext(databaseHistorieContext);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();