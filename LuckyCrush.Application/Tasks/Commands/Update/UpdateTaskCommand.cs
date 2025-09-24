using LuckyCrush.Application.Goals.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.Update;

public class UpdateTaskCommand : IRequest<Result>
{
    public int TaskId { get; set; }
    public int TypeId { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }

    public List<GoalDto> Goals { get; set; } = [];
}
