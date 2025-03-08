using Microsoft.Extensions.DependencyInjection;
using PrecisionFarming.Application.Common.Interfaces;
using PrecisionFarming.Application.Common.Services;
using PrecisionFarming.Application.Crop.Interfaces;
using PrecisionFarming.Application.Crop.Services;
using PrecisionFarming.Application.Farm.Interfaces;
using PrecisionFarming.Application.Farm.Services;
using PrecisionFarming.Application.Field.Interfaces;
using PrecisionFarming.Application.Field.Services;
using PrecisionFarming.Application.FieldCrop.Interfaces;
using PrecisionFarming.Application.FieldCrop.Services;

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

            services.AddScoped<ICreateFieldService, CreateFieldService>();
            services.AddScoped<IGetFieldService, GetFieldService>();
            services.AddScoped<IDeleteFieldService, DeleteFieldService>();
            services.AddScoped<IUpdateFieldService, UpdateFieldService>();

            services.AddScoped<ICreateFieldCropService, CreateFieldCropService>();
            services.AddScoped<IGetFieldCropService, GetFieldCropService>();
            services.AddScoped<IDeleteFieldCropService, DeleteFieldCropService>();
            services.AddScoped<IUpdateFieldCropService, UpdateFieldCropService>();

            services.AddScoped<IGetCropService, GetCropService>();
            services.AddScoped<IGetCropVarietyService, GetCropVarietyService>();

            services.AddScoped<IJwtService, JwtService>();
            return services;
        }
    }
}
