using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class PrizeRepository : GenericRepository<Prize>, IPrizeRepository
{
    public PrizeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
