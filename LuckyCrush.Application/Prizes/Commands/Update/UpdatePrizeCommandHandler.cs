using AutoMapper;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.Update;

public class UpdatePrizeCommandHandler(ILogger<UpdatePrizeCommandHandler> logger, IMapper mapper,
    IPrizeRepository prizeRepository, IFileService fileService) : IRequestHandler<UpdatePrizeCommand, Result>
{
    public async Task<Result> Handle(UpdatePrizeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating prize of id: {Id} with {@Prize}", request.PrizeId, request);
        var existing = await prizeRepository.FindByIdAsync(request.PrizeId);
        if (existing == null)
        {
            return Result.Failure("Prize not found");
        }

        mapper.Map(request, existing);
        if (request.Image != null)
        {
            if (!string.IsNullOrEmpty(existing.Image))
                fileService.DeleteFile(existing.Image);

            existing.Image = await fileService.SaveFileAsync(request.Image, "Images/Prizes/", [".jpg", ".png", ".jpeg"]);
        }
        await prizeRepository.SaveChangesAsync();
        return Result.Success();
    }
}
