using LuckyCrush.Application.Prizes.Dtos;
using MediatR;

namespace LuckyCrush.Application.Prizes.Queries.GetAll;

public class GetAllPrizesQuery : IRequest<IEnumerable<PrizeDto>>
{
}
