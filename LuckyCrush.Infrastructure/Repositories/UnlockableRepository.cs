using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class UnlockableRepository : GenericRepository<Unlockable>, IUnlockableRepository
{
    public UnlockableRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}
