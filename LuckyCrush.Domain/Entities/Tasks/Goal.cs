namespace LuckyCrush.Domain.Entities.Tasks;

public class Goal
{
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public int Target { get; set; }
    public int TaskId { get; set; }
    public GoalTask Task { get; set; } = default!;
    public List<Progress> Progresses { get; set; } = [];
}
