using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.Delete;

public class DeleteWheelCommandHandler(ILogger<DeleteWheelCommandHandler> logger,
    IWheelRepository wheelRepository) : IRequestHandler<DeleteWheelCommand, Result>
{
    public async Task<Result> Handle(DeleteWheelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting wheel with id: {Id}", request.WheelId);
        var existing = await wheelRepository.FindByIdAsync(request.WheelId);
        if (existing == null)
        {
            return Result.Failure("Wheel not found");
        }

        await wheelRepository.HardDeleteAsync(existing);
        return Result.Success();
    }
}
