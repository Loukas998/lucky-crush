using AutoMapper;
using LuckyCrush.Application.Spins.Dtos;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Spins.Queries.GetAll;

public class GetAllSpinsQueryHandler(ILogger<GetAllSpinsQueryHandler> logger, IMapper mapper,
    ISpinRepository spinRepository) : IRequestHandler<GetAllSpinsQuery, IEnumerable<SpinDto>>
{
    public async Task<IEnumerable<SpinDto>> Handle(GetAllSpinsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all spins");
        var spins = await spinRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<SpinDto>>(spins);
        return results;
    }
}
