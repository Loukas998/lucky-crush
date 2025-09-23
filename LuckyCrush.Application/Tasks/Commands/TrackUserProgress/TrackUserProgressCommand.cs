using MediatR;

namespace LuckyCrush.Application.Tasks.Commands.TrackUserProgress;

public class TrackUserProgressCommand : IRequest
{
    public string UserId { get; set; } = string.Empty;
    public int GoalId { get; set; }
    public int TaskId { get; set; }
    public int Amount { get; set; }
}
