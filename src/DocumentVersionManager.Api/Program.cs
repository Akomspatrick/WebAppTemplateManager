using DocumentVersionManager.Api;
using DocumentVersionManager.Api.Filters;
//using DocumentVersionManager.Api.Middleware;
using DocumentVersionManager.Application;
using DocumentVersionManager.Infrastructure;
using DocumentVersionManager.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using MySql.Data.MySqlClient;

var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllers();
    // if I want to use Filters fr error handling
    //builder.Services.AddControllers(option=> option.Filters.Add<ErrorHandlingFilterAttribute>());
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(options =>options.SwaggerDoc("v1", new OpenApiInfo { Title = "DocumentVersionManager.Api", Version = "v7" }));
    //builder.Services.AddDbContext<DocumentVersionManagerDbContext>(options =>
    //{
    //    options.UseMySql(builder.Configuration.GetConnectionString("constr"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("constr")));
    //});
    builder.Services.AddAPIServices(builder.Configuration);
    builder.Services.AddInfrastructure(builder.Configuration);
    builder.Services.AddApplicationServices(builder.Configuration);
}


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
});
// if i want to use middleware for error handling
//app.UseMiddleware<ErrorHandlingMiddleware>();
app.UseExceptionHandler("/error");
app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();
app.Run();
