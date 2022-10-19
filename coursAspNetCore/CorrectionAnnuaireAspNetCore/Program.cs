using CorrectionAnnuaireAspNetCore.Repositories;
using CorrectionAnnuaireAspNetCore.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Ajouter un service dbContext d'entityframeworkcore 
builder.Services.AddDbContext<DataDbContext>();

//Ajout d'un services
//builder.Services.AddTransient<ContactRepository>();
builder.Services.AddScoped<ContactRepository>();
//builder.Services.AddSingleton<ContactRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
