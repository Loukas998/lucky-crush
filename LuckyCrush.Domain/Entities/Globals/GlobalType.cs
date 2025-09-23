using LuckyCrush.Domain.Entities.Tasks;

namespace LuckyCrush.Domain.Entities.Globals;

public class GlobalType
{
    public int Id { get; set; }
    public string TypeName { get; set; } = default!; // GiftType, RewardType, TaskType
    public string Name { get; set; } = default!;

    public List<Reward> Rewards { get; set; } = [];
    public List<GoalTask> Tasks { get; set; } = [];
}
