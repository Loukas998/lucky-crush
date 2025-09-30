using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.Delete;

public class DeleteTaskCommand(int taskId) : IRequest<Result>
{
    public int TaskId { get; } = taskId;
}
