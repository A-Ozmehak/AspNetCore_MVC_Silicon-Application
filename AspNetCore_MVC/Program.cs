using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

builder.Services.AddScoped<FeatureRepository>();
builder.Services.AddScoped<FeatureItemRepository>();
builder.Services.AddScoped<ShowcaseRepository>();
builder.Services.AddScoped<BrandRepository>();
builder.Services.AddScoped<ManageWorkRepository>();
builder.Services.AddScoped<TextIconRepository>();
builder.Services.AddScoped<DownloadAppRepository>();
builder.Services.AddScoped<AppRepository>();
builder.Services.AddScoped<TopToolRepository>();
builder.Services.AddScoped<ToolRepository>();


builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<ManageWorkService>();
builder.Services.AddScoped<DownloadAppService>();
builder.Services.AddScoped<TopToolService>();


var app = builder.Build();
app.UseHsts();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
