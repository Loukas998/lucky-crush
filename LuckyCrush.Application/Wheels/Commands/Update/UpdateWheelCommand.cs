using MediatR;

namespace LuckyCrush.Application.Wheels.Commands.Update;

public class UpdateWheelCommand : IRequest
{
    public int WheelId { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public bool IsActive { get; set; }
    public string Type { get; set; } = default!; // Daily, Ad, Diamond
}
