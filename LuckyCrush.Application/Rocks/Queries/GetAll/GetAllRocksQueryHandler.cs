using AutoMapper;
using LuckyCrush.Application.Rocks.Dtos;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Rocks.Queries.GetAll;

public class GetAllRocksQueryHandler(ILogger<GetAllRocksQueryHandler> logger, IMapper mapper,
    IRockRepository rockRepository) : IRequestHandler<GetAllRocksQuery, IEnumerable<RockDto>>
{
    public async Task<IEnumerable<RockDto>> Handle(GetAllRocksQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all rocks");
        var rocks = await rockRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<RockDto>>(rocks);
        return results;
    }
}

