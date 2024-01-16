using DocumentVersionManager.Api;
using DocumentVersionManager.Api.Filters;
using DocumentVersionManager.Api.Middleware;

using DocumentVersionManager.Application;
using DocumentVersionManager.Infrastructure;
using DocumentVersionManager.Infrastructure.Persistence;
using Microsoft.OpenApi.Models;


var builder = WebApplication.CreateBuilder(args);
{
    // Add services to the container.
    builder.Services.AddControllers();
    // if I want to use Filters fr error handling
    //builder.Services.AddControllers(option=> option.Filters.Add<ErrorHandlingFilterAttribute>());
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    //builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo { Title = "DocumentVersionManager.Api", Version = "v7" }));
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
//if I want to use the error handling controller
//app.UseExceptionHandler("/error");
// this method  for the global exception handler ia same as the controllr style
app.UseExceptionHandler();

app.UseHttpsRedirection();
//app.UseAuthorization();
app.MapControllers();


//app.Run(async (HttpContext ctx) =>
//{
//    var headers = ctx.Request.Headers;
//    var useragent = headers["User-Agent"];


//    await ctx.Response.WriteAsync($"Hello World! from {useragent}");
//});

if (app.Environment.IsDevelopment())
{
    await TrySeedData.EnsureUsers(app);
}
app.Run();
