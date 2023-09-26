using DocumentVersionManager.Api;
using DocumentVersionManager.Application;
using DocumentVersionManager.Infrastructure;
using DocumentVersionManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
builder.Services.AddAPIServices();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
//builder.Services.AddDbContextPool<DocumentVersionManagerContext>(option => option.UseMySQL(builder.Configuration.GetConnectionString("constr")));


//builder.Services.AddTransient<MySqlConnection>(_ =>
//    new MySqlConnection(builder.Configuration.GetConnectionString("Default")));

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
