using AutoMapper;
using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Matches.Commands.Start;

public class StartMatchCommandHandler(ILogger<StartMatchCommandHandler> logger, IMapper mapper,
    IMatchRepository matchRepository, ILevelRepository levelRepository) : IRequestHandler<StartMatchCommand, int>
{
    public async Task<int> Handle(StartMatchCommand request, CancellationToken cancellationToken)
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
        return created.Id;
    }
}
