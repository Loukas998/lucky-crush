using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Queries.GetPlayerPrizes;

public class GetPlayerPrizesQuery : IRequest<Result<IEnumerable<PrizeDto>>>
{
}
