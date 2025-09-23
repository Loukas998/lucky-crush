using MediatR;

namespace LuckyCrush.Application.Spins.Commands.Create;

public class CreateSpinCommand : IRequest<int>
{
    public string UserId { get; set; } = default!;
    public int WheelId { get; set; } = default!;
    public DateTime SpinAt { get; set; }
    public string Type { get; set; } = default!; // Free, Paid
}
