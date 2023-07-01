using CardCore.Infrastructure.Abstractions;
using CardCore.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedisPackage.DependencyInjection;
using Serilog;

namespace CardCore.Infrastructure
{
    public static class RegisterInfrastructure
    {
        public static IServiceCollection RegistereInfrastructureDI(this IServiceCollection services, IConfiguration configuration){
            var logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .WriteTo.Console()
            .CreateLogger();
            services.AddSingleton<ILogger>((opt) => logger);
            services.AddRedisCached(opt =>
            {
                opt.ConnectionString = configuration.GetSection("RedisSettings:ConnectionString")?.Value ?? "";
                opt.DB = int.Parse(configuration.GetSection("RedisSettings:DB")?.Value ?? "0");
                opt.IsEncrypted = bool.Parse(configuration.GetSection("RedisSettings:IsEncrypted")?.Value ?? "false");
                opt.EncryptedKey = configuration.GetSection("RedisSettings:EncryptedKey")?.Value;
            });
            services.AddDistributedMemoryCache(opt => {
                opt.TrackStatistics = false;
            });
            services.AddDbContextPool<CardDbContext>(opt => {
                opt.UseSqlServer(configuration.GetConnectionString("CardCoreDb"));
            });
            services.AddScoped<ICardDbContext>(opt => opt.GetRequiredService<CardDbContext>());
            return services;
        }
    }
}