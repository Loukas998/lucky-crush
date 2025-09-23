using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Update;

public class UpdateUnlockableCommandHandler(ILogger<UpdateUnlockableCommandHandler> logger, IMapper mapper,
    IUnlockableRepository unlockableRepository) : IRequestHandler<UpdateUnlockableCommand>
{
    public async Task Handle(UpdateUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating unlockable with id: {Id}, with {@Unlockable}", request.UnlockableId, request);
        var existing = await unlockableRepository.FindByIdAsync(request.UnlockableId);
        if (existing == null)
        {

        }

        mapper.Map(request, existing);
        await unlockableRepository.SaveChangesAsync();
    }
}
