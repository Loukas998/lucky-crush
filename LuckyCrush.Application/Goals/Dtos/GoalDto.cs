namespace LuckyCrush.Application.Goals.Dtos;

public class GoalDto
{
    public string Name { get; set; } = default!;
    public int Target { get; set; }
    public int TaskId { get; set; }
}
