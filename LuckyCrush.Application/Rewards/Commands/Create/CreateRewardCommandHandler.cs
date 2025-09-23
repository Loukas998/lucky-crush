using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.Create;

public class CreateRewardCommandHandler(ILogger<CreateRewardCommandHandler> logger, IMapper mapper,
    IRewardRepository rewardRepository) : IRequestHandler<CreateRewardCommand, int>
{
    public async Task<int> Handle(CreateRewardCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new reward: {@Reward}", request);
        var reward = mapper.Map<Reward>(request);

        var created = await rewardRepository.AddAsync(reward);
        return created.Id;
    }
}
