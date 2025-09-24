using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.AssignPrizes;

public class AssignPrizesCommandHandler(ILogger<AssignPrizesCommandHandler> logger,
    IWheelRepository wheelRepository, IPrizeRepository prizeRepository) : IRequestHandler<AssignPrizesCommand, Result>
{
    public async Task<Result> Handle(AssignPrizesCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning prizes to wheel with id: {Id}", request.WheelId);
        var wheel = await wheelRepository.FindByIdAsync(request.WheelId);
        if (wheel == null)
        {
            return Result.Failure("Wheel not found");
        }

        foreach (int id in request.PrizesIds)
        {
            var prize = await prizeRepository.FindByIdAsync(id);
            if (prize == null)
            {
                return Result.Failure($"Could not find prize with id: {id}");
            }

            wheel.Prizes.Add(prize);
        }

        await wheelRepository.SaveChangesAsync();
        return Result.Success();
    }
}
