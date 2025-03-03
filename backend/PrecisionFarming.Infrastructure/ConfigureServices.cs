using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PrecisionFarming.Domain.Interfaces.Repositories;
using PrecisionFarming.Infrastructure.DbContext;
using PrecisionFarming.Infrastructure.Repositories;

namespace PrecisionFarming.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(config.GetConnectionString("DefaultConnection"), sql => sql.UseNetTopologySuite());
            });

            services.AddScoped<IFarmRepository, FarmRepository>();
            services.AddScoped<IFarmAccessRepository, FarmAccessRepository>();
            services.AddScoped<IFieldRepository, FieldRepository>();

            return services;
        }
    }
}
