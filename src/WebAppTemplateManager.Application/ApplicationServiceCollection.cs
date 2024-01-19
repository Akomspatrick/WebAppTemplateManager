﻿using WebAppTemplateManager.Application.Behaviours;
using WebAppTemplateManager.Application.CQRS.ModelType.Commands;
using WebAppTemplateManager.Application.Validators;
using WebAppTemplateManager.Domain.Interfaces;
using FluentAssertions.Common;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplateManager.Application;

public static class ApplicationServiceCollection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {

        var applicationAssembly = typeof(ApplicationServiceCollection).Assembly;
        services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ApplicationAssemblyReferenceMarker>());
        services.AddScoped(typeof(IPipelineBehavior<,>), typeof(LoggingPipelineBehaviour<,>));
        services.AddScoped<IPipelineBehavior<CreateModelTypeCommand, int>, ValidationModelTypeBehaviour>();
        //Instead of adding individual fluent validation we can add Fluentvalidation asp.netcore package and then 
        //services.AddScoped<IValidator<AddNewModelTypeCommand>, AddNewModelTypeValidator>();
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        return services;
    }
}
