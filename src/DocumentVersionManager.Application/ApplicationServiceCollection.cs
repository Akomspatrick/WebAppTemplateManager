using DocumentVersionManager.Domain.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Application;

    public static class ApplicationServiceCollection
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(ApplicationServiceCollection).Assembly;
        services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Class1>()); 
        
        return services;    
        }
    }
