using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.Delete;

public class DeleteTaskCommand : IRequest<Result>
{
    public int TaskId { get; set; }
}
