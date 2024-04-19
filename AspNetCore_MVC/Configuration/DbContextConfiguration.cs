using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace AspNetCore_MVC.Configuration;

public static class DbContextConfiguration
{
    public static void RegisterDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(x => x.UseSqlServer(configuration.GetConnectionString("SqlServer")));
    }
}
