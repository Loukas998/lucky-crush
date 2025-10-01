using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Response;
using MediatR;

namespace LuckyCrush.Application.Users.Queries.GetPlayerBalance;

public class GetPlayerBalanceQuery : IRequest<Result<BalanceDto>>
{
}
