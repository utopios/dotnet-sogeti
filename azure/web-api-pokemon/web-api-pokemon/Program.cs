using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
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
builder.Services.AddCors(options =>
{
    options.AddPolicy("all", policyBuilder =>
    {
        policyBuilder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    } );
});
builder.Services.AddDbContext<DataBaseContext>();
builder.Services.AddScoped<PokemonRepository>();
builder.Services.AddScoped<UserAppRepository>();
builder.Services.AddScoped<PokemonService>();
builder.Services.AddScoped<UserAppService>();
builder.Services.AddScoped<ILogin,LoginJwtService>();
builder.Services.AddScoped<IPasswordHash,PasswordHashService>();
builder.Services.AddScoped<IUpload,UploadService>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication(a =>
{
    a.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    a.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o => o.TokenValidationParameters = new TokenValidationParameters()
{
    ValidateIssuerSigningKey = true,
    ValidateIssuer = true,
    ValidIssuer = "sogeti",
    ValidateLifetime = true,
    ValidateAudience = true,
    ValidAudience = "sogeti",
    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Bonjour je suis la clé de sécurité pour générer la JWT")),

});
builder.Services.AddAuthorization((builder) =>
{
    builder.AddPolicy("admin", options =>
    {
        options.RequireRole("admin");
    });
    
    builder.AddPolicy("user", options =>
    {
        options.RequireRole("admin", "user");
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("all");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();