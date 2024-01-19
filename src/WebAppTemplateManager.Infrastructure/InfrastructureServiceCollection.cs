using WebAppTemplateManager.Application.Contracts.Logging;
using WebAppTemplateManager.Domain.Interfaces;
using WebAppTemplateManager.Domain.Utils;
using WebAppTemplateManager.Infrastructure.Logging;
using WebAppTemplateManager.Infrastructure.Persistence;
using WebAppTemplateManager.Infrastructure.Persistence.Repositories;
using WebAppTemplateManager.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace WebAppTemplateManager.Infrastructure
{
    public static class InfrastructureServiceCollection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var applicationAssembly = typeof(InfrastructureServiceCollection).Assembly;

            // services.AddAutoMapper(applicationAssembly);
            //services.AddMediatR(c => c.RegisterServicesFromAssemblyContaining<ModelTypesRepository>());
            // services.AddExceptionHandler<GlobalExceptionHandler.GlobalExceptionHandler>();
            var constr = GetConnectionstringName.GetConnectionStrName(Environment.MachineName);
            // services.AddDbContext<WebAppTemplateManagerContext>(option => option.UseMySQL(configuration.GetConnectionString(Domain.Constants.FixedValues.DBConnectionStringName)!));
            services.AddDbContext<WebAppTemplateManagerContext>(option => option.UseMySql(configuration.GetConnectionString(constr)!, GeneralUtils.GetMySqlVersion()));


            services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
