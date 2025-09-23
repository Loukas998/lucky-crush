using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.AssignToUser;

public class AssignUnlockableToUserCommandHandler(ILogger<AssignUnlockableToUserCommandHandler> logger,
    IUnlockableRepository unlockableRepository, IAccountRepository accountRepository) : IRequestHandler<AssignUnlockableToUserCommand>
{
    public async Task Handle(AssignUnlockableToUserCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning unlockable to user");

        var user = await accountRepository.GetUserByIdAsync(request.UserId);
        if (user == null)
        {

        }

        var unlockable = await unlockableRepository.FindByIdAsync(request.UnlockableId);
        if (unlockable == null)
        {

        }

        user.Unlockables.Add(unlockable);
    }
}
