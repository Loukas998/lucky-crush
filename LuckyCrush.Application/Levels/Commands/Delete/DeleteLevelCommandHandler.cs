using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Levels.Commands.Delete;

public class DeleteLevelCommandHandler(ILogger<DeleteLevelCommandHandler> logger,
    ILevelRepository levelRepository) : IRequestHandler<DeleteLevelCommand>
{
    public async Task Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting level with id: {Id}", request.LevelId);
        var level = await levelRepository.GetLevelWithRequirementAsync(request.LevelId);
        if (level == null)
        {

        }

        await levelRepository.DeleteAsync(level);
    }
}
