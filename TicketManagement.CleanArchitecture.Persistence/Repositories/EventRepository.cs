using Microsoft.EntityFrameworkCore;
using TicketManagement.CleanArchitecture.Application.Contracts.Persistence;
using TicketManagement.CleanArchitecture.Domain.Entities;

namespace TicketManagement.CleanArchitecture.Persistence.Repositories
{
    public class EventRepository : BaseRepository<Event>, IEventRepository
    {
        public EventRepository(TicketManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<bool> IsEventNameAndDateUnique(string name, DateTime eventDate)
        {
            return await _dbContext.Events.AnyAsync(e => e.Name == name && e.Date.Date == eventDate.Date);
        }
    }
}
