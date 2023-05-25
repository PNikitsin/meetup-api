using Meetups.Domain.Entities;
using Meetups.Infrastructure.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace Meetups.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Meetup> Meetups { get; set; }
        public DbSet<User> Users { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MeetupConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());
        }
    }
}