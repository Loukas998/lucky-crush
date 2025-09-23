using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Commands.Update;

public class UpdateRockCommandHandler(ILogger<UpdateRockCommandHandler> logger, IMapper mapper,
    IRockRepository rockRepository) : IRequestHandler<UpdateRockCommand>
{
    public async Task Handle(UpdateRockCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating rock with id: {Id} with {@Rock}", request.RockId, request);
        var existing = await rockRepository.FindByIdAsync(request.RockId);
        if (existing != null)
        {

        }

        var result = mapper.Map(request, existing);
        if (request.ImagePath != null)
        {

        }

        await rockRepository.SaveChangesAsync();
    }
}
