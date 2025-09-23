using LuckyCrush.Domain.Entities.Globals;
namespace LuckyCrush.Domain.Entities.Tasks;

public class GoalTask
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public GlobalType Type { get; set; } = default!;
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<Goal> Goals { get; set; } = [];
}
