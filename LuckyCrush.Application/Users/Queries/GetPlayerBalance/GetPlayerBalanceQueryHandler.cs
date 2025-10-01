using AutoMapper;
using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Queries.GetPlayerBalance;

public class GetPlayerBalanceQueryHandler(ILogger<GetPlayerBalanceQueryHandler> logger
    , IAccountRepository accountRepository, IUserContext userContext, IMapper mapper)
    : IRequestHandler<GetPlayerBalanceQuery, Result<BalanceDto>>
{
    public async Task<Result<BalanceDto>> Handle(GetPlayerBalanceQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting current player balance");

        var currentUserId = userContext.GetCurrentUser()!.Id;
        var balance = await accountRepository.GetPlayerBalanceAsync(currentUserId);
        var result = mapper.Map<BalanceDto>(balance);
        return Result<BalanceDto>.Success(result);
    }
}
