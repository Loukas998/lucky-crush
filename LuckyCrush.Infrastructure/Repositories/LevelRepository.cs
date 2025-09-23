using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LuckyCrush.Infrastructure.Repositories;

public class LevelRepository : GenericRepository<Level>, ILevelRepository
{
    public LevelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Level?> GetLevelWithRequirementAsync(int levelId)
    {
        return dbContext.Levels
            .Include(l => l.Requirements)
            .FirstOrDefaultAsync(l => l.Id == levelId);
    }

    public async Task<Level?> GetLevelWithUserProgress(int levelId, string userId)
    {
        var level = await dbContext.Levels
            .Include(l => l.UserLevels.Where(l => l.UserId == userId))
            .FirstOrDefaultAsync(l => l.Id == levelId);
        return level;
    }
}
