using MediatR;

namespace LuckyCrush.Application.Wheels.Commands.Delete;

public class DeleteWheelCommand : IRequest
{
    public int WheelId { get; set; }
}
