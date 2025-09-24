using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Prizes.Queries.GetAll;

public class GetAllPrizesQuery : IRequest<Result<IEnumerable<PrizeDto>>>
{
}
