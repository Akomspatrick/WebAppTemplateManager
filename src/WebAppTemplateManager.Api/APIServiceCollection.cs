using Asp.Versioning;
using WebAppTemplateManager.Domain.Utils;
using WebAppTemplateManager.Infrastructure.GlobalExceptionHandler;
using WebAppTemplateManager.Infrastructure.Persistence;
using WebAppTemplateManager.Infrastructure.Utils;
using LanguageExt.TypeClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplateManager.Api;

public static class APIServiceCollection
{
    public static IServiceCollection AddAPIServices(this IServiceCollection services, IConfiguration configuration)
    {

        var applicationAssembly = typeof(APIServiceCollection).Assembly;
        services.AddAutoMapper(applicationAssembly);
        services.AddExceptionHandler<GlobalExceptionHandler>();
        //services.AddExceptionHandler<GlobalExceptionHandler.GlobalExceptionHandler>();
        services.AddProblemDetails();
        services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());

        services.AddCors();
        services.AddApiVersioning(
            option =>
            {
                option.ReportApiVersions = true;
                option.AssumeDefaultVersionWhenUnspecified = true;
                option.DefaultApiVersion = new ApiVersion(2, 0);
                option.ApiVersionReader = ApiVersionReader.Combine(
                    new QueryStringApiVersionReader("api-version"),
                    new HeaderApiVersionReader("api-version"),
                    new MediaTypeApiVersionReader("version")
                    );


            });

        // services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
        return services;
    }
}




