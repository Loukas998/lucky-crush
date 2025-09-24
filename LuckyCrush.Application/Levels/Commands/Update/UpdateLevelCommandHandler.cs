using AutoMapper;
using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Levels.Commands.Update;

public class UpdateLevelCommandHandler(
    ILogger<UpdateLevelCommandHandler> logger,
    IMapper mapper,
    ILevelRepository levelRepository
) : IRequestHandler<UpdateLevelCommand, Result>
{
    public async Task<Result> Handle(UpdateLevelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating Level {LevelId}", request.LevelId);

        var level = await levelRepository.FindByIdAsync(request.LevelId);
        if (level == null)
        {
            logger.LogWarning("Level {LevelId} not found", request.LevelId);
            return Result.Failure("Level not found");
        }

        level.Number = request.Number;
        level.IsSpecial = request.IsSpecial;
        level.RequiredStars = request.RequiredStars;

        level.Requirements = mapper.Map<List<Requirement>>(request.Requirements);

        await levelRepository.UpdateAsync(level);

        logger.LogInformation("Level {LevelId} updated successfully", request.LevelId);
        return Result.Success();
    }
}
