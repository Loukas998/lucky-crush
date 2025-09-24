using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.Delete;

public class DeleteRewardCommandHandler(ILogger<DeleteRewardCommandHandler> logger,
    IRewardRepository rewardRepository) : IRequestHandler<DeleteRewardCommand, Result>
{
    public async Task<Result> Handle(DeleteRewardCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting reward with id: {RewardId}", request.RewardId);
        var existing = await rewardRepository.FindByIdAsync(request.RewardId);
        if (existing == null)
        {
            return Result.Failure("Reward");
        }

        await rewardRepository.DeleteAsync(existing);
        return Result.Success();
    }
}
