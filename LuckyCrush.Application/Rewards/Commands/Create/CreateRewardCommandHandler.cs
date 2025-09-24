using AutoMapper;
using LuckyCrush.Domain.Entities.Tasks;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rewards.Commands.Create;

public class CreateRewardCommandHandler(ILogger<CreateRewardCommandHandler> logger, IMapper mapper,
    IRewardRepository rewardRepository) : IRequestHandler<CreateRewardCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateRewardCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new reward: {@Reward}", request);
        var reward = mapper.Map<Reward>(request);

        var created = await rewardRepository.AddAsync(reward);
        return Result<int>.Success(created.Id);
    }
}
