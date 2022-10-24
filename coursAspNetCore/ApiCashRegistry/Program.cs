using ApiCashRegistry.Repositories;
using ApiCashRegistry.Services;
using ApiCashRegistry.Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<UserRespository>();
builder.Services.AddScoped<ProductRepository>();
builder.Services.AddScoped<OrderRespository>();
builder.Services.AddScoped<JWTService>();

builder.Services.AddDbContext<DataDbContext>();
builder.Services.AddAuthentication();


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
