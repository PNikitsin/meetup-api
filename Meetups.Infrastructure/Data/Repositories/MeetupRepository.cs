using Meetups.Domain.Entities;
using Meetups.Domain.Interfaces;

namespace Meetups.Infrastructure.Data.Repositories
{
    internal class MeetupRepository : GenericRepository<Meetup>, IMeetupRepository
    {
        public MeetupRepository(AppDbContext dbContext)
            : base(dbContext) { }
    }
}