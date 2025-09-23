using MediatR;

namespace LuckyCrush.Application.Wheels.Commands.Create;

public class CreateWheelCommand : IRequest<int>
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; } = default!; // Daily, Ad, Diamond
}
