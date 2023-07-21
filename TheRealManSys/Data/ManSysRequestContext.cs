using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using TheRealManSys.Models;
using TheRealManSys.Models.Requests;

namespace TheRealManSys.Data
{
    public class ManSysRequestContext : DbContext
    {
        public DbSet<Request> request { get; set; }
        public DbSet<Comment> comments { get; set; }
        public DbSet<Status> statuses { get; set; }
        public DbSet<Contact> contacts { get; set; }
        public DbSet<Item> items { get; set; }
        public DbSet<Draft> drafts { get; set; }
        public DbSet<DraftItem> draftItems { get; set; }

        public ManSysRequestContext(DbContextOptions<ManSysRequestContext> context) : base(context) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
}