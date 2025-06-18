using MF.Application.Services;
using MF.Domain.Interfaces.Repositories;
using MF.Domain.Interfaces.Services;
using MF.Infrastructure.Configurations;
using MF.Infrastructure.Repositories;
using MF.Infrastructure.Security;
using MF.Infrastructure.SeedDB;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace MF.Api.DependencyInjection
{
    public static class DependencyInyectionHandler
    {
        public static void DepencyInyectionConfig(this IServiceCollection services)
        {

            IConfigurationBuilder builder = new ConfigurationBuilder().AddJsonFile("appsettings.json");

            IConfiguration configuration = builder.Build();

            services.AddSingleton(configuration);
            RegisterDbContext(services, configuration);
            #region Automapper

            services.AddAutoMapper(Assembly.Load("MF.Domain"));

            #endregion Automapper
            RegisterRepositories(services);
            RegisterServices(services);
            services.AddTransient<SeedDB>();
        }

        private static void RegisterDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ManufacturingContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ManuFacturingConnectionString")));
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductImportService, ProductImportService>();
            services.AddScoped<IElaborationTypeService, ElaborationTypeService>();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IQueryableUnitOfWork, ManufacturingContext>();
            services.AddScoped<ITokenGenerator, TokenGenerator>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IElaborationTypeRepository, ElaborationTypeRepository>();
        }
    }
}
