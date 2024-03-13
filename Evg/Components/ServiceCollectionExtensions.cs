// Метод расширения ServiceCollectionExtension
namespace Evg.Components.Models;

using Microsoft.Extensions.Configuration;

public static class ServiceCollectionExtension
{
    public static void AddSettings1(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<AppSettings>(configuration.GetSection("ConnectionStrings"));
    }
}