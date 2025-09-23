using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.Delete;

public class DeleteWheelCommandHandler(ILogger<DeleteWheelCommandHandler> logger,
    IWheelRepository wheelRepository) : IRequestHandler<DeleteWheelCommand>
{
    public async Task Handle(DeleteWheelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting wheel with id: {Id}", request.WheelId);
        var existing = await wheelRepository.FindByIdAsync(request.WheelId);
        if (existing == null)
        {

        }

        await wheelRepository.DeleteAsync(existing);
    }
}
