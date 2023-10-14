using Meetups.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Meetups.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}