using MediatR;

namespace LuckyCrush.Application.Rewards.Commands.AssignToUser;

public class AssignRewardToUserCommand : IRequest
{
    public string UserId { get; set; } = string.Empty;
    public int TaskId { get; set; }
    public int RewardId { get; set; }
}
