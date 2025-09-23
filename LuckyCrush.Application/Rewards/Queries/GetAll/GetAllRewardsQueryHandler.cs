using AutoMapper;
using LuckyCrush.Application.Rewards.Dtos;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Queries.GetAll;

public class GetAllRewardsQueryHandler(ILogger<GetAllRewardsQueryHandler> logger,
    IRewardRepository rewardRepository, IMapper mapper)
    : IRequestHandler<GetAllRewardsQuery, IEnumerable<RewardDto>>
{
    public async Task<IEnumerable<RewardDto>> Handle(GetAllRewardsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all rewards");
        var rewards = await rewardRepository.GetAllAsync();

        var results = mapper.Map<IEnumerable<RewardDto>>(rewards);
        return results;
    }
}
