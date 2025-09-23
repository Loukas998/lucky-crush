using LuckyCrush.Domain.Entities.Levels;

namespace LuckyCrush.Domain.Repositories;

public interface IMatchRepository : IGenericRepository<Match>
{
    public Task<Match?> GetMatchWithLevelRequirements(int matchId);
}
