using LuckyCrush.Application.Users.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.Login;

public class LoginCommandHandler(ILogger<LoginCommandHandler> logger,
    ITokenRepository tokenRepository)
    : IRequestHandler<LoginCommand, Result<LoginResponse>>
{
    public async Task<Result<LoginResponse>> Handle(LoginCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Logging in");

        var login = await tokenRepository.Login(request.UserId);
        if (login == null)
        {
            return Result<LoginResponse>.Failure("User doesn't exist");
        }
        var response = new LoginResponse
        {
            AccessToken = login.Value.AccessToken,
            RefreshToken = login.Value.RefreshToken,
            DurationInMinutes = login.Value.DurationInMinutes,
        };

        return Result<LoginResponse>.Success(response);
    }
}
