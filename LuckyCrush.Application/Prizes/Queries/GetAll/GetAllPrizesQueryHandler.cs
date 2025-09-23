using AutoMapper;
using LuckyCrush.Application.Prizes.Dtos;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Prizes.Queries.GetAll;

public class GetAllPrizesQueryHandler(ILogger<GetAllPrizesQueryHandler> logger, IMapper mapper,
    IPrizeRepository prizeRepository) : IRequestHandler<GetAllPrizesQuery, IEnumerable<PrizeDto>>
{
    public async Task<IEnumerable<PrizeDto>> Handle(GetAllPrizesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all prizes");
        var prizes = await prizeRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<PrizeDto>>(prizes);
        return results;
    }
}
