using AutoMapper;
using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Create;

public class CreateUnlockableCommandHandler(ILogger<CreateUnlockableCommandHandler> logger, IMapper mapper,
    IUnlockableRepository unlockableRepository, IFileService fileService)
    : IRequestHandler<CreateUnlockableCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new unlockable: {@Unlockable}", request);
        var unlockable = mapper.Map<Unlockable>(request);
        if (request.Image != null)
        {
            unlockable.ImagePath = await fileService.SaveFileAsync(request.Image, "Images/Unlockables/", [".jpg", ".png", ".jpeg"]);
        }

        var created = await unlockableRepository.AddAsync(unlockable);
        return Result<int>.Success(created.Id);
    }
}
