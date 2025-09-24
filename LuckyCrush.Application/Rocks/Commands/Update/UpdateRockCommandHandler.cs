using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Commands.Update;

public class UpdateRockCommandHandler(ILogger<UpdateRockCommandHandler> logger, IMapper mapper,
    IRockRepository rockRepository, IFileService fileService) : IRequestHandler<UpdateRockCommand, Result>
{
    public async Task<Result> Handle(UpdateRockCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating rock with id: {Id} with {@Rock}", request.RockId, request);
        var existing = await rockRepository.FindByIdAsync(request.RockId);
        if (existing == null)
        {
            return Result.Failure("Rock not found");
        }

        var result = mapper.Map(request, existing);
        if (request.Image != null)
        {
            if (!string.IsNullOrEmpty(existing.ImagePath))
            {
                fileService.DeleteFile(existing.ImagePath);
            }
            existing.ImagePath = await fileService.SaveFileAsync(request.Image, "Images/Rocks/", [".jpg", ".png", ".jpeg"]);
        }

        await rockRepository.SaveChangesAsync();
        return Result.Success();
    }
}
