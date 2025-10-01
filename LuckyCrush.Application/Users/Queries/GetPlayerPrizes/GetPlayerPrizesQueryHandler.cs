using AutoMapper;
using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Queries.GetPlayerPrizes;

public class GetPlayerPrizesQueryHandler(ILogger<GetPlayerPrizesQueryHandler> logger,
    IAccountRepository accountRepository, IUserContext userContext, IMapper mapper)
    : IRequestHandler<GetPlayerPrizesQuery, Result<IEnumerable<PrizeDto>>>
{
    public async Task<Result<IEnumerable<PrizeDto>>> Handle(GetPlayerPrizesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting current player prizes");
        var currentUserId = userContext.GetCurrentUser()!.Id;

        var prizes = await accountRepository.GetPlayerPrizesAsync(currentUserId);
        var results = mapper.Map<IEnumerable<PrizeDto>>(prizes);
        return Result<IEnumerable<PrizeDto>>.Success(results);
    }
}
