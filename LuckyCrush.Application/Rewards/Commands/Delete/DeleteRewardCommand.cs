using MediatR;

namespace LuckyCrush.Application.Rewards.Commands.Delete;

public class DeleteRewardCommand : IRequest
{
    public int RewardId { get; set; }
}
