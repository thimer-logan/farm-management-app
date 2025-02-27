using Microsoft.Extensions.DependencyInjection;
using PrecisionFarming.Application.Common.Interfaces;
using PrecisionFarming.Application.Common.Services;
using PrecisionFarming.Application.Farm.Interfaces;
using PrecisionFarming.Application.Farm.Services;

namespace PrecisionFarming.Application
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<ICreateFarmService, CreateFarmService>();
            services.AddScoped<IGetFarmService, GetFarmService>();
            services.AddScoped<IDeleteFarmService, DeleteFarmService>();
            services.AddScoped<IUpdateFarmService, UpdateFarmService>();

            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
