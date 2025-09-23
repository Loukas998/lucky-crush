using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Commands.Delete;

public class DeleteRockCommandHandler(ILogger<DeleteRockCommandHandler> logger,
    IRockRepository rockRepository) : IRequestHandler<DeleteRockCommand>
{
    public async Task Handle(DeleteRockCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting rock with id: {Id}", request.RockId);
        var existing = await rockRepository.FindByIdAsync(request.RockId);
        if (existing != null)
        {

        }

        // delete image
        await rockRepository.DeleteAsync(existing);
    }
}
