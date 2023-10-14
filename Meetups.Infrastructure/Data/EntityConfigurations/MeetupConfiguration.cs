using Meetups.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Meetups.Infrastructure.Data.EntityConfigurations
{
    internal class MeetupConfiguration : IEntityTypeConfiguration<Meetup>
    {
        public void Configure(EntityTypeBuilder<Meetup> builder)
        {
            builder.ToTable("Meetups");

            builder.HasKey(k => k.Id);

            builder.Property(p => p.Name).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Address).HasMaxLength(64).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(512).IsRequired();
        }
    }
}