using AutoMapper;
using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Application.Levels.Queries.GetAll;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Levels.Queries.GetById;

public class GetLevelByIdQueryHandler(ILogger<GetAllLevelsQueryHandler> logger, IMapper mapper,
    ILevelRepository levelRepository) : IRequestHandler<GetLevelByIdQuery, Result<LevelDto>>
{
    public async Task<Result<LevelDto>> Handle(GetLevelByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting level by id: {Id}", request.LevelId);
        var level = await levelRepository.GetLevelWithRequirementAsync(request.LevelId);
        if (level == null)
        {
            return Result<LevelDto>.Failure("Level not found");
        }

        var result = mapper.Map<LevelDto>(level);
        return Result<LevelDto>.Success(result);
    }
}
