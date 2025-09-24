using AutoMapper;
using LuckyCrush.Application.Levels.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Levels.Queries.GetAll;

public class GetAllLevelsQueryHandler(ILogger<GetAllLevelsQueryHandler> logger, IMapper mapper,
    ILevelRepository levelRepository) : IRequestHandler<GetAllLevelsQuery, Result<IEnumerable<LevelDto>>>
{
    public async Task<Result<IEnumerable<LevelDto>>> Handle(GetAllLevelsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all levels");
        var levels = await levelRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<LevelDto>>(levels);
        return Result<IEnumerable<LevelDto>>.Success(results);
    }
}
