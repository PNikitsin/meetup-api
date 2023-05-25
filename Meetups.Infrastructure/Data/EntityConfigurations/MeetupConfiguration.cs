using Meetups.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetups.Infrastructure.Data.EntityConfigurations
{
    internal class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.Property(p =>  p.Name).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Description).IsRequired().HasMaxLength(520);
            builder.Property(p => p.Speaker).IsRequired().HasMaxLength(64);
            builder.Property(p => p.Location).IsRequired().HasMaxLength(64);
        }
    }
}