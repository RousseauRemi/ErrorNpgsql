using System.Text;
using System.Text.Json;
using ErrorNpgsql.Datas;
using Microsoft.EntityFrameworkCore;

namespace ErrorNpgsql.Configuration;

/// <summary>
/// 
/// </summary>
public static class IocDataConfigurationExtension
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection AddDataLayerRunTime(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext(configuration);
    }


    internal static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        services.AddDbContext<CustomDbContext>(config =>
        {
            config.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            config.EnableSensitiveDataLogging(true);
            config.EnableDetailedErrors();
            config.UseNpgsql(connectionString,
                o =>
                {
                    o.UseNetTopologySuite();
                });
        });
        return services;
    }
}