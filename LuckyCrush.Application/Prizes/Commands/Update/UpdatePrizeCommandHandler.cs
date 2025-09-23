using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.Update;

public class UpdatePrizeCommandHandler(ILogger<UpdatePrizeCommandHandler> logger, IMapper mapper,
    IPrizeRepository prizeRepository) : IRequestHandler<UpdatePrizeCommand>
{
    public async Task Handle(UpdatePrizeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating prize of id: {Id} with {@Prize}", request.PrizeId, request);
        var existing = await prizeRepository.FindByIdAsync(request.PrizeId);
        if (existing == null)
        {

        }

        mapper.Map(request, existing);
        await prizeRepository.SaveChangesAsync();
    }
}
