using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Delete;

public class DeleteUnlockableCommandHandler(ILogger<DeleteUnlockableCommandHandler> logger,
    IUnlockableRepository unlockableRepository) : IRequestHandler<DeleteUnlockableCommand>
{
    public async Task Handle(DeleteUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting unlockable with id: {Id}", request.UnlockableId);
        var existing = await unlockableRepository.FindByIdAsync(request.UnlockableId);
        if (existing == null)
        {

        }

        await unlockableRepository.DeleteAsync(existing);
    }
}
