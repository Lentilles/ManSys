using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ManSys.Data;
using ManSys.Models;
using ManSys.Data.RequestScripts;
using ManSys.Data.CommentScripts;
using ManSys.Data.ItemScripts;
using ManSys.Data.StatusScripts;

var builder = WebApplication.CreateBuilder(args);
var DbConnectionString = builder.Configuration.GetConnectionString("Default") ?? throw new InvalidOperationException("Connection string 'Identity' not found.");

builder.Services.AddDbContext<ManSysIdentityContext>(options => options.UseNpgsql(DbConnectionString));
builder.Services.AddDbContext<ManSysRequestContext>(options => options.UseNpgsql(DbConnectionString));

builder.Services.AddDefaultIdentity<User>
    (options => options.SignIn.RequireConfirmedAccount = false)
        .AddRoles<Role>()
            .AddEntityFrameworkStores<ManSysIdentityContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequiredLength = 6;
    options.Password.RequiredUniqueChars = 1;
    options.Password.RequireNonAlphanumeric = false;

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
    options.Lockout.MaxFailedAccessAttempts = 10;
    options.Lockout.AllowedForNewUsers = true;

    options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-.@";
    options.User.RequireUniqueEmail = true;
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.HttpOnly = true;
    options.ExpireTimeSpan = TimeSpan.FromDays(1);
    options.Cookie.Name = "ManSys";
    options.SlidingExpiration = true;
    options.AccessDeniedPath = "/Account/AccessDenied";
    options.LoginPath = "/Account/Login";
    options.LogoutPath = "/Account/Logout";
});


builder.Services.AddScoped<RequestManager>();
builder.Services.AddScoped<CommentManager>();
builder.Services.AddScoped<ItemManager>();
builder.Services.AddScoped<StatusManager>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


