using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Commands.Create;

public class CreatePrizeCommandHandler(ILogger<CreatePrizeCommandHandler> logger, IMapper mapper,
    IPrizeRepository prizeRepository) : IRequestHandler<CreatePrizeCommand, int>
{
    public async Task<int> Handle(CreatePrizeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new prize: {@Prize}", request);
        var prize = mapper.Map<Prize>(request);

        var created = await prizeRepository.AddAsync(prize);
        return created.Id;
    }
}
