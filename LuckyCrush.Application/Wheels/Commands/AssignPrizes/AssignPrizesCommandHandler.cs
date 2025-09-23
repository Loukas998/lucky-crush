using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.AssignPrizes;

public class AssignPrizesCommandHandler(ILogger<AssignPrizesCommandHandler> logger, IMapper mapper,
    IWheelRepository wheelRepository, IPrizeRepository prizeRepository) : IRequestHandler<AssignPrizesCommand>
{
    public async Task Handle(AssignPrizesCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Assigning prizes to wheel with id: {Id}", request.WheelId);
        var wheel = await wheelRepository.FindByIdAsync(request.WheelId);
        if (wheel == null)
        {

        }

        foreach (int id in request.PrizesIds)
        {
            var prize = await prizeRepository.FindByIdAsync(id);
            if (prize == null)
            {

            }

            wheel.Prizes.Add(prize);
        }

        await wheelRepository.SaveChangesAsync();
    }
}
