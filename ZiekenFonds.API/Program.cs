using Microsoft.EntityFrameworkCore;
using ZiekenFonds.API.Data;
using ZiekenFonds.API.Data.UnitOfWork;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ZiekenFondsApiContext>(options => options
    .UseSqlServer(builder.Configuration.GetConnectionString("LocalDBConnection")));

// Service voor UnitOfWork
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

// Service voor Automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

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
