using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class WheelRepository : GenericRepository<Wheel>, IWheelRepository
{
    public WheelRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
