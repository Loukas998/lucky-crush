using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LuckyCrush.Infrastructure.Repositories;

public class SpinRepository : GenericRepository<Spin>, ISpinRepository
{
    public SpinRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<int> CountTodayAsync(string userId, string type)
    {
        var todayUtc = DateTime.UtcNow.Date;
        var tomorrowUtc = todayUtc.AddDays(1);

        return await dbContext.Spins
            .AsNoTracking()
            .CountAsync(s =>
                s.UserId == userId &&
                s.Type == type &&
                s.SpinAt >= todayUtc &&
                s.SpinAt < tomorrowUtc);
    }

    public async Task<Spin?> GetByCorrelationIdAsync(string correlationId)
    {
        return await dbContext.Spins
            .FirstOrDefaultAsync(s => s.CorrelationId == correlationId);
    }
}
