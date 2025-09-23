using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.Delete;

public class DeleteRewardCommandHandler(ILogger<DeleteRewardCommandHandler> logger,
    IRewardRepository rewardRepository) : IRequestHandler<DeleteRewardCommand>
{
    public async Task Handle(DeleteRewardCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting reward with id: {RewardId}", request.RewardId);
        var existing = await rewardRepository.FindByIdAsync(request.RewardId);
        if (existing == null)
        {

        }

        await rewardRepository.DeleteAsync(existing);
    }
}
