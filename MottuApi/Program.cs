using Microsoft.EntityFrameworkCore;
using MottuTest.Api.DataStore.Postgres;
using MottuTest.Api.DataStore.Postgres.DataAccess;
using MottuTest.Api.Services;
using MottuTest.Model.Models;
using MottuTest.Model.Translators;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<ICommands, Commands>();
builder.Services.AddScoped<IQueries,Queries>();
builder.Services.AddScoped<IToUrlEntityTranslator, ToUrlEntityTranslator>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Database
builder.Services.AddEntityFrameworkNpgsql()
  .AddDbContext<Context>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("mottutestConnectionString"))
  );


var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
