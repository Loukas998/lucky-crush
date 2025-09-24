using LuckyCrush.Domain.Entities.Wheels;

namespace LuckyCrush.Domain.Repositories;

public interface IWheelRepository : IGenericRepository<Wheel>
{
    Task<Wheel?> GetWheelWithPrizesAsync(int wheelId);
}
