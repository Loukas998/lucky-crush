using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Domain.Repositories;

public interface ISpinRepository : IGenericRepository<Spin>
{
    public Task<Spin?> GetByCorrelationIdAsync(string correlationId);
    Task<int> CountTodayAsync(string userId, string type);

}
