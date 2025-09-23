using LuckyCrush.Domain.Entities.Game;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class RockRepository : GenericRepository<Rock>, IRockRepository
{
    public RockRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
