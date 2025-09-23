using LuckyCrush.Application.Goals.Dtos;
using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.Create;

public class CreateTaskCommand : IRequest<int>
{
    public int TypeId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<GoalDto> Goals { get; set; } = [];
}
