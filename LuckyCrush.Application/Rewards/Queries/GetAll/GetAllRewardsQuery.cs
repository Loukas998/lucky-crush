using LuckyCrush.Application.Rewards.Dtos;
using MediatR;

namespace LuckyCrush.Application.Rewards.Queries.GetAll;

public class GetAllRewardsQuery : IRequest<IEnumerable<RewardDto>>
{
}
