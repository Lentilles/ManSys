using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TheRealManSys.Data;
using TheRealManSys.Models;

var builder = WebApplication.CreateBuilder(args);
var Identity = builder.Configuration.GetConnectionString("Identity") ?? throw new InvalidOperationException("Connection string 'Identity' not found.");

builder.Services.AddDbContext<ManSysIdentityContext>(options => options.UseNpgsql(Identity));
builder.Services.AddDbContext<ManSysRequestContext>(options => options.UseNpgsql(Identity));

builder.Services.AddDefaultIdentity<User>
    (options => options.SignIn.RequireConfirmedAccount = true)
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


