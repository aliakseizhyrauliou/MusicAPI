using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MusicAPI;
using MusicAPI.DbStuff;
using MusicAPI.DbStuff.Repositories;
using MusicAPI.DbStuff.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JulyIdea.IdeasAPI;Integrated Security=True;";
builder.Services.AddDbContext<WebContext>(options =>
    options.UseSqlServer(connectString));
builder.Services.AddScoped<IDbSeed, DbSeed>();
IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

builder.Services.AddSingleton(mapper);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped<ITracksRepository, TracksRepository>();
var app = builder.Build();

var scopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();

using (var scope = scopeFactory.CreateScope())
{
    var dbInitializer = scope.ServiceProvider.GetService<IDbSeed>();
    dbInitializer.Initialize();
}

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
