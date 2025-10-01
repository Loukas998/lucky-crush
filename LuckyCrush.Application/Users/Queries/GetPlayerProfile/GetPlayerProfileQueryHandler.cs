using AutoMapper;
using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Queries.GetPlayerProfile;

public class GetPlayerProfileQueryHandler(ILogger<GetPlayerProfileQueryHandler> logger,
    IAccountRepository accountRepository, IUserContext userContext, IMapper mapper)
    : IRequestHandler<GetPlayerProfileQuery, Result<ProfileDto>>
{
    public async Task<Result<ProfileDto>> Handle(GetPlayerProfileQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting current player profile");

        var currentUserId = userContext.GetCurrentUser()!.Id;
        var profile = await accountRepository.GetPlayerProfileAsync(currentUserId);
        var result = mapper.Map<ProfileDto>(profile);
        return Result<ProfileDto>.Success(result);
    }
}
