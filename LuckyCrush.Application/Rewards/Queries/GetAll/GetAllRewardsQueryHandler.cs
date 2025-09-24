using AutoMapper;
using LuckyCrush.Application.Rewards.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Queries.GetAll;

public class GetAllRewardsQueryHandler(ILogger<GetAllRewardsQueryHandler> logger,
    IRewardRepository rewardRepository, IMapper mapper)
    : IRequestHandler<GetAllRewardsQuery, Result<IEnumerable<RewardDto>>>
{
    public async Task<Result<IEnumerable<RewardDto>>> Handle(GetAllRewardsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all rewards");
        var rewards = await rewardRepository.GetAllAsync();

        var results = mapper.Map<IEnumerable<RewardDto>>(rewards);
        return Result<IEnumerable<RewardDto>>.Success(results);
    }
}
