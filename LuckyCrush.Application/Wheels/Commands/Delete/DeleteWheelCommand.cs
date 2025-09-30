using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Wheels.Commands.Delete;

public class DeleteWheelCommand(int wheelId) : IRequest<Result>
{
    public int WheelId { get; } = wheelId;
}
