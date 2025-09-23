using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class SpinRepository : GenericRepository<Spin>, ISpinRepository
{
    public SpinRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }
}
