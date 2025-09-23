using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace LuckyCrush.Infrastructure.Repositories;

public class TaskRepository : GenericRepository<GoalTask>, ITaskRepository
{
    public TaskRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<GoalTask?> GetTaskWithGoals(int taskId)
    {
        var goal = await dbContext.Tasks
            .Include(t => t.Goals)
            .FirstOrDefaultAsync(t => t.Id == taskId);

        return goal;
    }
}
