using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LuckyCrush.Infrastructure.Repositories;

public class MatchRepository : GenericRepository<Match>, IMatchRepository
{
    public MatchRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Task<Match?> GetMatchWithLevelRequirements(int matchId)
    {
        return dbContext.Matches
            .Include(m => m.Level)
                .ThenInclude(l => l.Requirements)
            .Include(m => m.Level)
                .ThenInclude(l => l.UserLevels)
            .FirstOrDefaultAsync(m => m.Id == matchId);
    }
}
