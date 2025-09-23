using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class RewardRepository : GenericRepository<Reward>, IRewardRepository
{
    public RewardRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
