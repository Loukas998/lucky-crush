using LuckyCrush.Domain.Entities.Tasks;

namespace LuckyCrush.Domain.Repositories;

public interface ITaskRepository : IGenericRepository<GoalTask>
{
    public Task<GoalTask?> GetTaskWithGoals(int taskId);
}
