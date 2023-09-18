using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Infrastructure.Persistence;
using DocumentVersionManager.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DocumentVersionManager.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public  static   IServiceCollection  AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(InfrastructureServiceCollection).Assembly; 

            services.AddAutoMapper(applicationAssembly);
            services.AddScoped<IModelRepository, IModelRepository>();   
            services.AddScoped<IModelTypesRepository, IModelTypesRepository>(); 
            services.AddScoped( typeof(IGenericRepository<>) , typeof(IGenericRepository<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<DocumentVersionManagerContext>(option => option.UseMySQL(configuration.GetConnectionString("constr")));


            return services;
        }
    }
}
