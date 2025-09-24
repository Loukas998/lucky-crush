using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Wheels.Commands.Delete;

public class DeleteWheelCommand : IRequest<Result>
{
    public int WheelId { get; set; }
}
