using Microsoft.EntityFrameworkCore;
using PokemonApi.Data;
using Microsoft.Extensions.DependencyInjection;
using PokemonApi.Repositories;
using PokemonApi.Services;
using NLog;
using NLog.Web;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup()
    .LoadConfigurationFromFile("nlog.config")
    .GetCurrentClassLogger();

try
{
    // Add services to the container.
    builder.Services.AddDbContext<DataContext>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
    builder.Services.AddScoped<IPokemonService, PokemonService>();

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

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
}
catch (Exception ex)
{
    LogManager.GetCurrentClassLogger().Error(ex, "Application stopped due to an exception");
    throw;
}
finally
{
    LogManager.Shutdown();
}

