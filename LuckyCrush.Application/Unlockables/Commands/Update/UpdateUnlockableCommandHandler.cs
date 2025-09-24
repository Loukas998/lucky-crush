using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Commands.Update;

public class UpdateUnlockableCommandHandler(ILogger<UpdateUnlockableCommandHandler> logger, IMapper mapper,
    IUnlockableRepository unlockableRepository, IFileService fileService)
    : IRequestHandler<UpdateUnlockableCommand, Result>
{
    public async Task<Result> Handle(UpdateUnlockableCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating unlockable with id: {Id}, with {@Unlockable}", request.UnlockableId, request);
        var existing = await unlockableRepository.FindByIdAsync(request.UnlockableId);
        if (existing == null)
        {
            return Result.Failure("Unlockable not found");
        }

        mapper.Map(request, existing);
        if (request.Image != null)
        {
            if (!string.IsNullOrEmpty(existing.ImagePath))
            {
                fileService.DeleteFile(existing.ImagePath);
            }
            existing.ImagePath = await fileService.SaveFileAsync(request.Image, "Images/Rocks/", [".jpg", ".png", ".jpeg"]);
        }
        await unlockableRepository.SaveChangesAsync();
        return Result.Success();
    }
}
