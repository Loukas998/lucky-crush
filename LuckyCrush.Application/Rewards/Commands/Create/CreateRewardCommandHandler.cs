using AutoMapper;
using LuckyCrush.Application.Rewards.Dtos;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.Create;

public class CreateRewardCommandHandler(ILogger<CreateRewardCommandHandler> logger, IMapper mapper,
    IRewardRepository rewardRepository) : IRequestHandler<CreateRewardCommand, Result<RewardDto>>
{
    public async Task<Result<RewardDto>> Handle(CreateRewardCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new reward: {@Reward}", request);
        var reward = mapper.Map<Reward>(request);

        var created = await rewardRepository.AddAsync(reward);
        var result = mapper.Map<RewardDto>(created);
        return Result<RewardDto>.Success(result);
    }
}
