using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.Update;

public class UpdateRewardCommandHandler(ILogger<UpdateRewardCommandHandler> logger, IMapper mapper,
    IRewardRepository rewardRepository) : IRequestHandler<UpdateRewardCommand>
{
    public async Task Handle(UpdateRewardCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating reward with id: {RewardId} with {@UpdateReward}", request.RewardId, request);
        var existing = await rewardRepository.FindByIdAsync(request.RewardId);
        if (existing == null)
        {

        }

        mapper.Map(request, existing);
        await rewardRepository.SaveChangesAsync();
    }
}
