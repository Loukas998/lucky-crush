using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LuckyCrush.Infrastructure.Repositories;

public class WheelRepository : GenericRepository<Wheel>, IWheelRepository
{
    public WheelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Wheel?> GetWheelWithPrizesAsync(int wheelId)
    {
        return await dbContext.Wheels
            .Include(w => w.Prizes)
            .FirstOrDefaultAsync();
    }
}
