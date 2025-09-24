using AutoMapper;
using LuckyCrush.Domain.Entities.Game;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using LuckyCrush.Domain.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Commands.Create;

public class CreateRockCommandHandler(ILogger<CreateRockCommandHandler> logger,
    IRockRepository rockRepository, IMapper mapper, IFileService fileService)
    : IRequestHandler<CreateRockCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateRockCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new rock: {@Rock}", request);
        var rock = mapper.Map<Rock>(request);
        if (request.Image != null)
        {
            rock.ImagePath = await fileService.SaveFileAsync(request.Image, "Images/Rocks/", [".jpg", ".png", ".jpeg"]);
        }

        var created = await rockRepository.AddAsync(rock);
        return Result<int>.Success(created.Id);
    }
}
