using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Rewards.Commands.Delete;

public class DeleteRewardCommand : IRequest<Result>
{
    public int RewardId { get; set; }
}
