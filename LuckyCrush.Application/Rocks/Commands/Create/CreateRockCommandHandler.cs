using AutoMapper;
using LuckyCrush.Domain.Entities.Game;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Commands.Create;

public class CreateRockCommandHandler(ILogger<CreateRockCommandHandler> logger,
    IRockRepository rockRepository, IMapper mapper) : IRequestHandler<CreateRockCommand, int>
{
    public async Task<int> Handle(CreateRockCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new rock: {@Rock}", request);
        var rock = mapper.Map<Rock>(request);
        if (request.ImagePath != null)
        {

        }

        var created = await rockRepository.AddAsync(rock);
        return created.Id;
    }
}
