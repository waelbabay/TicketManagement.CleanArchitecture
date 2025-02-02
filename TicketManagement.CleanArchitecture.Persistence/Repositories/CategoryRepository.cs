using Microsoft.EntityFrameworkCore;
using TicketManagement.CleanArchitecture.Application.Contracts.Persistence;
using TicketManagement.CleanArchitecture.Domain.Entities;

namespace TicketManagement.CleanArchitecture.Persistence.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(TicketManagementDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Category>> GetCategoriesWithEvents(bool includeHistory)
        {
            List<Category> categories = await _dbContext.Categories.Include(c => c.Events).ToListAsync();

            if (!includeHistory)
            {
                categories.ForEach(c => c.Events?.ToList().RemoveAll(e => e.Date.Date < DateTime.Today));
                // categories.ForEach(c => c.Events = c.Events?.Where(e => e.Date.Date >= DateTime.Today).ToList());
            }

            return categories;
        }
    }
}
