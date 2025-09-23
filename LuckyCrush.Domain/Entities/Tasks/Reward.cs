using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Entities.Globals;

namespace LuckyCrush.Domain.Entities.Tasks;

public class Reward
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public GlobalType Type { get; set; } = default!;
    public int TaskId { get; set; }
    public GoalTask Task { get; set; } = default!;
    public int Amount { get; set; }
    public List<User> Users { get; set; } = [];
}
