using DocumentVersionManager.Application.Contracts.Logging;
using DocumentVersionManager.Domain.Interfaces;
using DocumentVersionManager.Domain.Utils;
using DocumentVersionManager.Infrastructure.Logging;
using DocumentVersionManager.Infrastructure.Persistence;
using DocumentVersionManager.Infrastructure.Persistence.Repositories;
using DocumentVersionManager.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            var constr = GetConnectionstringName.GetConnectionStrName(Environment.MachineName);
            // services.AddDbContext<DocumentVersionManagerContext>(option => option.UseMySQL(configuration.GetConnectionString(Domain.Constants.FixedValues.DBConnectionStringName)!));
            services.AddDbContext<DocumentVersionManagerContext>(option => option.UseMySql(configuration.GetConnectionString(constr)!, GeneralUtils.GetMySqlVersion()));

            services.AddScoped<IModelRepository, ModelRepository>();
            services.AddScoped<IModelTypeRepository, ModelTypeRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
