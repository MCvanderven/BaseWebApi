using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BaseWebApi.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<SolAppContext>(options =>
    // options.UseSqlServer(builder.Configuration.GetConnectionString("SolAppContext") ?? throw new InvalidOperationException("Connection string 'SolAppContext' not found.")));
    options.UseInMemoryDatabase("CowManagerSolDb"));
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
