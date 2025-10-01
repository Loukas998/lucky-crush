using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.RefreshToken;

public class RefreshTokenCommandHandler(ILogger<RefreshTokenCommandHandler> logger,
    ITokenRepository tokenRepository, IUserContext userContext)
    : IRequestHandler<RefreshTokenCommand, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Refreshing token");
        var currentUser = userContext.GetCurrentUser();
        var userId = currentUser!.Id;

        var response = await tokenRepository.VerifyRefreshToken(userId, request.RefreshToken);
        var refresh = new LoginResponse
        {
            AccessToken = response.Value.AccessToken,
            RefreshToken = response.Value.RefreshToken,
            DurationInMinutes = response.Value.DurationInMinutes,
        };

        return Result<LoginResponse>.Success(refresh);
    }
}
