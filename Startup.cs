using System.Text.Json;
using irctc.Repository;
using irctc.Repository.Interface;
using irctc.Service;
using irctc.Service.Interface;

namespace irctc
{
    public static class Startup
    {
        public static void AddStartupConfigurations(this WebApplicationBuilder builder)
        {
            builder.Services.AddScoped<IStationRepository, StationRepository>();
            builder.Services.AddScoped<IStationService, StationService>();

            builder.Services.AddScoped<ITrainServiceRepository, TrainServiceRepository>();
            builder.Services.AddScoped<ITrainService, TrainService>();

            builder.Services.AddHttpClient();

            builder.Services.AddControllers().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    policy =>
                    {
                        policy.AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod();
                    });
            });
        }
    }
}