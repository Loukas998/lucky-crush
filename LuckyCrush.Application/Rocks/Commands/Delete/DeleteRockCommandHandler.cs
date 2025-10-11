using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Commands.Delete;

public class DeleteRockCommandHandler(ILogger<DeleteRockCommandHandler> logger,
    IRockRepository rockRepository) : IRequestHandler<DeleteRockCommand, Result>
{
    public async Task<Result> Handle(DeleteRockCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting rock with id: {Id}", request.RockId);
        var existing = await rockRepository.FindByIdAsync(request.RockId);
        if (existing == null)
        {
            return Result.Failure("Rock not found");
        }

        // delete image
        await rockRepository.HardDeleteAsync(existing);
        return Result.Success();
    }
}
