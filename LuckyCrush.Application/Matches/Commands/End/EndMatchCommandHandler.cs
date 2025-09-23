using LuckyCrush.Domain.Entities.Levels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Matches.Commands.End;

public class EndMatchCommandHandler(ILogger<EndMatchCommandHandler> logger,
    IMatchRepository matchRepository, ILevelRepository levelRepository) : IRequestHandler<EndMatchCommand>
{
    public async Task Handle(EndMatchCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Finishing match of id: {Id}", request.MatchId);

        var match = await matchRepository.GetMatchWithLevelRequirements(request.MatchId);
        if (match == null)
        {

        }

        match.EndedAt = DateTime.UtcNow;
        match.Won = request.Won;
        match.StarsCollected = request.StarsCollected;

        var requirements = match.Level.Requirements;
        var destructions = request.Destructions;
        bool fulfilledRequirements = !requirements.Any() || requirements.All(req =>
        {
            var destruction = destructions.FirstOrDefault(d => d.RockId == req.RockId);
            return destruction != null && destruction.QuantityDestructed >= req.Quantity;
        });

        var userLevel = match.Level.UserLevels
            .Where(ul => ul.LevelId == match.LevelId)
            .Where(ul => ul.UserId == match.UserId)
            .FirstOrDefault();

        if (userLevel == null)
        {
            var newUserLevel = new UserLevel
            {
                Attempts = 1,
                UserId = match.UserId,
                LevelId = match.LevelId,
                BestStars = match.StarsCollected,
                CompletedAt = fulfilledRequirements ? DateTime.UtcNow : null,
            };
            match.Level.UserLevels.Add(newUserLevel);
        }
        else
        {
            userLevel.BestStars = Math.Max(request.StarsCollected, userLevel.BestStars);
            userLevel.Attempts++;
            if (userLevel.CompletedAt == null)
            {
                userLevel.CompletedAt = fulfilledRequirements ? DateTime.UtcNow : null;
            }
        }

        await matchRepository.SaveChangesAsync();
    }
}
