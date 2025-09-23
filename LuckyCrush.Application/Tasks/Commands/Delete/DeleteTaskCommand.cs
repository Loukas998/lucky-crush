using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.Delete;

public class DeleteTaskCommand : IRequest
{
    public int TaskId { get; set; }
}
