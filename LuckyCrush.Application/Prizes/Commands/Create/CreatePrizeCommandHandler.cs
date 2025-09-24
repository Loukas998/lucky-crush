using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.Create;

public class CreatePrizeCommandHandler(ILogger<CreatePrizeCommandHandler> logger, IMapper mapper,
    IPrizeRepository prizeRepository, IFileService fileService) : IRequestHandler<CreatePrizeCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreatePrizeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new prize: {@Prize}", request);
        var prize = mapper.Map<Prize>(request);

        if (request.Image != null)
        {
            string imagePath = await fileService.SaveFileAsync(request.Image, "Images/Prizes/", [".jpg", ".png", ".jpeg"]);
            prize.Image = imagePath;
        }
        var created = await prizeRepository.AddAsync(prize);
        return Result<int>.Success(created.Id);
    }
}
