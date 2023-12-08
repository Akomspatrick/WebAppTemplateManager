using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Infrastructure.Logging;
using DocumentVersionManager.Infrastructure.Persistence;
using DocumentVersionManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Org.BouncyCastle.Asn1.X509.Qualified;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(InfrastructureServiceCollection).Assembly;

            // services.AddAutoMapper(applicationAssembly);
            //services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ModelTypesRepository>());
            // services.AddExceptionHandler<GlobalExceptionHandler.GlobalExceptionHandler>();

            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IModelTypesRepository, ModelTypesRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
