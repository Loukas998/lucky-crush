using AutoMapper;
using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.Create;

public class CreatePrizeCommandHandler(ILogger<CreatePrizeCommandHandler> logger, IMapper mapper,
    IPrizeRepository prizeRepository, IFileService fileService) : IRequestHandler<CreatePrizeCommand, Result<PrizeDto>>
{
    public async Task<Result<PrizeDto>> Handle(CreatePrizeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new prize: {@Prize}", request);
        var prize = mapper.Map<Prize>(request);

        if (request.Image != null)
        {
            string imagePath = await fileService.SaveFileAsync(request.Image, "Images/Prizes/", [".jpg", ".png", ".jpeg"]);
            prize.Image = imagePath;
        }
        var created = await prizeRepository.AddAsync(prize);
        var result = mapper.Map<PrizeDto>(created);
        return Result<PrizeDto>.Success(result);
    }
}
