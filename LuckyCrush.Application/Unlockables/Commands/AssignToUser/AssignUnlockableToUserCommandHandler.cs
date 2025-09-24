using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.AssignToUser;

public class AssignUnlockableToUserCommandHandler(ILogger<AssignUnlockableToUserCommandHandler> logger,
    IUnlockableRepository unlockableRepository, IAccountRepository accountRepository)
    : IRequestHandler<AssignUnlockableToUserCommand, Result>
{
    public async Task<Result> Handle(AssignUnlockableToUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning unlockable to user");

        var user = await accountRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {
            return Result.Failure("User not found");
        }

        var unlockable = await unlockableRepository.FindByIdAsync(request.UnlockableId);
        if (unlockable == null)
        {
            return Result.Failure("Unlockable not found");
        }

        user.Unlockables.Add(unlockable);
        return Result.Success();
    }
}
