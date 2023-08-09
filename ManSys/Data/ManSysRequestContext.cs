using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using ManSys.Models;
using ManSys.Models.Requests;

namespace ManSys.Data
{
    public class ManSysRequestContext : DbContext
    {
        public DbSet<Request> request { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Item> items { get; set; }
        public ManSysRequestContext(DbContextOptions<ManSysRequestContext> context) : base(context) { }
        public ManSysRequestContext() : base() 
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            #region request
            builder.Entity<Request>()
                .HasOne(request => request.Creator)
                .WithMany();

            builder.Entity<Request>()
                .HasOne(request => request.Manager)
                .WithMany();

            builder.Entity<Request>()
                .HasOne(request => request.Delivery)
                .WithMany();

            builder.Entity<Request>()
                .HasOne(request => request.GeneralStatus)
                .WithOne()
                .HasForeignKey<Request>(request => request.GeneralStatusId);
            #endregion

            #region item
            builder.Entity<Item>()
                .HasOne(item => item.Request)
                .WithMany(request => request.Items)
                .HasForeignKey(item => item.RequestId)
                .HasPrincipalKey(request => request.Id);

            builder.Entity<Item>()
                .HasOne(item => item.Status)
                .WithOne()
                .HasForeignKey<Item>(item => item.StatusId);

            builder.Entity<Item>()
                .HasOne(item => item.VendorContacts)
                .WithOne()
                .HasForeignKey<Item>(item => item.VendorId);

            #endregion




        }
    }
}