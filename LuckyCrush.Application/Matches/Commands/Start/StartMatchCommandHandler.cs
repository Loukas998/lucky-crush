using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Matches.Commands.Start;

public class StartMatchCommandHandler(ILogger<StartMatchCommandHandler> logger,
    IMatchRepository matchRepository) : IRequestHandler<StartMatchCommand, Result<int>>
{
    public async Task<Result<int>> Handle(StartMatchCommand request, CancellationToken cancellationToken)
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
        return Result<int>.Success(created.Id);
    }
}
