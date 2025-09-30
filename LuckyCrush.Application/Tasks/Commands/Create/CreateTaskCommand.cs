using LuckyCrush.Application.Goals.Dtos;
using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.Create;

public class CreateTaskCommand : IRequest<Result<GoalTaskDto>>
{
    public int TypeId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public List<GoalDto> Goals { get; set; } = [];
}
