using MediatR;

namespace LuckyCrush.Application.Wheels.Commands.AssignPrizes;

public class AssignPrizesCommand : IRequest
{
    public List<int> PrizesIds { get; set; } = [];
    public int WheelId { get; set; }
}
