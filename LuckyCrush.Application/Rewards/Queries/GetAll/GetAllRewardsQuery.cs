using LuckyCrush.Application.Rewards.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Rewards.Queries.GetAll;

public class GetAllRewardsQuery : IRequest<Result<IEnumerable<RewardDto>>>
{
}
