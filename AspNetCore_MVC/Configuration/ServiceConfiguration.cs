using Infrastructure.Contexts;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_MVC.Configuration;

public static class ServiceConfiguration
{
    public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<CategoryService>();
        services.AddScoped<FeatureService>();
        services.AddScoped<ShowcaseService>();
        services.AddScoped<ManageWorkService>();
        services.AddScoped<DownloadAppService>();
        services.AddScoped<TopToolService>();
        services.AddScoped<SliderService>();
        services.AddScoped<AddressService>();
        services.AddScoped<CourseService>();
    }
}
