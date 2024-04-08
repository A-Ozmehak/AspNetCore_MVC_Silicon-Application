using AspNetCore_MVC.Helpers.Middlewares;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
builder.Services.AddDefaultIdentity<UserEntity>(x =>
{
    x.User.RequireUniqueEmail = true;
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
}).AddEntityFrameworkStores<DataContext>();

builder.Services.ConfigureApplicationCookie(x =>
{
    x.LoginPath = "/signin";
    x.LogoutPath = "/signout";
    x.AccessDeniedPath = "/denied";

    x.Cookie.HttpOnly = true;
    x.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    x.ExpireTimeSpan = TimeSpan.FromMinutes(60);
    x.SlidingExpiration = true;
});

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
builder.Services.AddScoped<SliderRepository>();


builder.Services.AddScoped<FeatureService>();
builder.Services.AddScoped<ShowcaseService>();
builder.Services.AddScoped<ManageWorkService>();
builder.Services.AddScoped<DownloadAppService>();
builder.Services.AddScoped<TopToolService>();
builder.Services.AddScoped<SliderService>();
builder.Services.AddScoped<AddressService>();


var app = builder.Build();
app.UseHsts();
app.UseStatusCodePagesWithReExecute("/Error", "?statusCode={0}");
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthentication();
app.UseUserSessionValidation();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
