using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.Logout;

public class LogoutCommandHandler(ILogger<LogoutCommandHandler> logger,
    IAccountRepository accountRepository) : IRequestHandler<LogoutCommand, Result>
{
    public async Task<Result> Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Logging out");
        await accountRepository.RevokeSession(request.Token);
        return Result.Success();
    }
}
