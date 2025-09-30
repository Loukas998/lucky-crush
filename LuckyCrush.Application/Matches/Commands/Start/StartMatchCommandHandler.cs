using AutoMapper;
using LuckyCrush.Application.Matches.Dtos;
using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Matches.Commands.Start;

public class StartMatchCommandHandler(ILogger<StartMatchCommandHandler> logger,
    IMatchRepository matchRepository, IMapper mapper) : IRequestHandler<StartMatchCommand, Result<MatchDto>>
{
    public async Task<Result<MatchDto>> Handle(StartMatchCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Starting match: {@Match}", request);
        var match = new Match
        {
            LevelId = request.LevelId,
            UserId = request.UserId,
            Won = false,
            StarsCollected = 0,
            StartedAt = DateTime.UtcNow,
        };

        var created = await matchRepository.AddAsync(match);
        var result = mapper.Map<MatchDto>(created);
        return Result<MatchDto>.Success(result);
    }
}
