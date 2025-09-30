using LuckyCrush.Application.Tasks.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Tasks.Queries.GetById;

public class GetTaskByIdQuery(int taskId) : IRequest<Result<GoalTaskDto>>
{
    public int TaskId { get; } = taskId;
}
