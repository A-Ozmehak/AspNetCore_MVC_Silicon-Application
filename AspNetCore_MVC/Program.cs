using AspNetCore_MVC.Helpers.Middlewares;
using Infrastructure.Contexts;
using Infrastructure.Entities;
using Infrastructure.Repositories;
using Infrastructure.Services;
using AspNetCore_MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRouting(x => x.LowercaseUrls = true);
builder.Services.AddControllersWithViews();
builder.Services.AddHttpClient();

builder.Services.RegisterDbContexts(builder.Configuration);
//builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));
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
builder.Services.AddScoped<SaveCoursesRepository>();

builder.Services.AddScoped<AccountManager>();

builder.Services.RegisterServices(builder.Configuration);

builder.Services.AddAuthentication().AddFacebook(x => {
    x.AppId = builder.Configuration["Authentication:Facebook:AppId"]!;
    x.AppSecret = builder.Configuration["Authentication:Facebook:AppSecret"]!;
    x.Fields.Add("first_name");
    x.Fields.Add("last_name");
});

object value = builder.Services.AddAuthentication()
      .AddGoogle(options =>
      {
          options.ClientId = builder.Configuration["Authentication:Google:ClientId"]!;
          options.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"]!;
          options.CallbackPath = "/signin-google";
      });


var app = builder.Build();
app.UseHsts();
app.UseStatusCodePagesWithReExecute("/Error/{0}");
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
