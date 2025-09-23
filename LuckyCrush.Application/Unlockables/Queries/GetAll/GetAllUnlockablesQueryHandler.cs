using AutoMapper;
using LuckyCrush.Application.Unlockables.Dtos;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Unlockables.Queries.GetAll;

public class GetAllUnlockablesQueryHandler(ILogger<GetAllUnlockablesQueryHandler> logger, IMapper mapper,
    IUnlockableRepository unlockableRepository) : IRequestHandler<GetAllUnlockablesQuery, IEnumerable<UnlockableDto>>
{
    public async Task<IEnumerable<UnlockableDto>> Handle(GetAllUnlockablesQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all unlockables");
        var unlockables = await unlockableRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<UnlockableDto>>(unlockables);
        return results;
    }
}
