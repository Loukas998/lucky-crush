using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Users.Commands.Logout;

public class LogoutCommandHandler(ILogger<LogoutCommandHandler> logger,
    IAccountRepository accountRepository) : IRequestHandler<LogoutCommand>
{
    public async Task Handle(LogoutCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Logging out");
        await accountRepository.RevokeSession(request.Token);

    }
}
