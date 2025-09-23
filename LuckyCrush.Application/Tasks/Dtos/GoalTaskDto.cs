using LuckyCrush.Application.Goals.Dtos;

namespace LuckyCrush.Application.Tasks.Dtos;

public class GoalTaskDto
{
    public int Id { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<GoalDto> Goals { get; set; } = [];
}