using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Api;

    public static class APIServiceCollection
    {
        public static IServiceCollection AddAPIServices(this IServiceCollection services)//, IConfiguration configuration)
        {
        //var applicationAssembly = typeof(APIServiceCollection).Assembly;
       
            
       // services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<Program>());
            return services;    
        }
    }
