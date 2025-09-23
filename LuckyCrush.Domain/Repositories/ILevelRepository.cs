using LuckyCrush.Domain.Entities.Levels;

namespace LuckyCrush.Domain.Repositories;

public interface ILevelRepository : IGenericRepository<Level>
{
    public Task<Level?> GetLevelWithRequirementAsync(int levelId);
    public Task<Level?> GetLevelWithUserProgress(int levelId, string userId);
}
