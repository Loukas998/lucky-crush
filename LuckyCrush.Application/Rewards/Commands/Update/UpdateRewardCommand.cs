using MediatR;

namespace LuckyCrush.Application.Rewards.Commands.Update;

public class UpdateRewardCommand : IRequest
{
    public int RewardId { get; set; }
    public int TypeId { get; set; }
    public int TaskId { get; set; }
    public int Amount { get; set; }
}