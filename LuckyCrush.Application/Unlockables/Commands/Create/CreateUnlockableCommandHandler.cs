using AutoMapper;
using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Create;

public class CreateUnlockableCommandHandler(ILogger<CreateUnlockableCommandHandler> logger, IMapper mapper,
    IUnlockableRepository unlockableRepository) : IRequestHandler<CreateUnlockableCommand, int>
{
    public async Task<int> Handle(CreateUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new unlockable: {@Unlockable}", request);
        var unlockable = mapper.Map<Unlockable>(request);

        var created = await unlockableRepository.AddAsync(unlockable);
        return created.Id;
    }
}
