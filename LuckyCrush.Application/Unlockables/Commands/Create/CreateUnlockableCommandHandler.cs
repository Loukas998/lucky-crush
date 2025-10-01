using AutoMapper;
using LuckyCrush.Application.Unlockables.Dtos;
using LuckyCrush.Domain.Entities.Account;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Create;

public class CreateUnlockableCommandHandler(ILogger<CreateUnlockableCommandHandler> logger, IMapper mapper,
    IUnlockableRepository unlockableRepository, IFileService fileService)
    : IRequestHandler<CreateUnlockableCommand, Result<UnlockableDto>>
{
    public async Task<Result<UnlockableDto>> Handle(CreateUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new unlockable: {@Unlockable}", request);
        var unlockable = mapper.Map<Unlockable>(request);
        if (request.Image != null)
        {
            unlockable.ImagePath = await fileService.SaveFileAsync(request.Image, "Images/Unlockables/", [".jpg", ".png", ".jpeg"]);
        }

        var created = await unlockableRepository.AddAsync(unlockable);
        var result = mapper.Map<UnlockableDto>(created);
        return Result<UnlockableDto>.Success(result);
    }
}
