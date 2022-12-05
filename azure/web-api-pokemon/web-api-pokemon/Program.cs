using web_api_pokemon.Models;
using web_api_pokemon.Repositories;
using web_api_pokemon.Repositories.Interfaces;
using web_api_pokemon.Services;
using web_api_pokemon.Services.Interfaces;
using web_api_pokemon.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddScoped<PokemonRepository>();
builder.Services.AddScoped<UserAppRepository>();
builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<UserAppService>();
builder.Services.AddScoped<ILogin,LoginJwtService>();
builder.Services.AddScoped<IPasswordHash,PasswordHashService>();
builder.Services.AddScoped<IUpload,UploadService>();


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