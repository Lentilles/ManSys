using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ManSys.Models;

namespace ManSys.Data;

public class ManSysIdentityContext : IdentityDbContext<User, Role, string>
{   
    public ManSysIdentityContext(DbContextOptions<ManSysIdentityContext> options) : base(options)
    {
    }    
    public ManSysIdentityContext() : base()
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }
}