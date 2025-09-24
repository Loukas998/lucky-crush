using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Delete;

public class DeleteUnlockableCommandHandler(ILogger<DeleteUnlockableCommandHandler> logger,
    IUnlockableRepository unlockableRepository) : IRequestHandler<DeleteUnlockableCommand, Result>
{
    public async Task<Result> Handle(DeleteUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting unlockable with id: {Id}", request.UnlockableId);
        var existing = await unlockableRepository.FindByIdAsync(request.UnlockableId);
        if (existing == null)
        {
            return Result.Failure("Unlockable not found");
        }

        await unlockableRepository.DeleteAsync(existing);
        return Result.Success();
    }
}
