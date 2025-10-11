using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Levels.Commands.Delete;

public class DeleteLevelCommandHandler(ILogger<DeleteLevelCommandHandler> logger,
    ILevelRepository levelRepository) : IRequestHandler<DeleteLevelCommand, Result>
{
    public async Task<Result> Handle(DeleteLevelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Deleting level with id: {Id}", request.LevelId);
        var level = await levelRepository.GetLevelWithRequirementAsync(request.LevelId);
        if (level == null)
        {
            return Result.Failure("Level not found");
        }

        await levelRepository.HardDeleteAsync(level);
        return Result.Success();
    }
}
