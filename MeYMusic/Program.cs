using MeMyMusicData;
using MeMyMusicData.Services;
using MeYMusic;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;


var builder = WebApplication.CreateBuilder(args);
LogManager.LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
builder.Logging.ClearProviders();
builder.WebHost.UseNLog();
builder.Services.AddDbContext<DataContext>(options =>
          options.UseSqlite(builder.Configuration.GetConnectionString("MeYMusicDatabase")));
builder.Services.AddTransient<MyGenresServices>();
builder.Services.AddTransient<MyArtistService>();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
