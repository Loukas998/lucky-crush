using LuckyCrush.Domain.Entities.Globals;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;

namespace LuckyCrush.Infrastructure.Repositories;

public class GlobalTypeRepository : GenericRepository<GlobalType>, IGlobalTypeRepository
{
    public GlobalTypeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }


}
