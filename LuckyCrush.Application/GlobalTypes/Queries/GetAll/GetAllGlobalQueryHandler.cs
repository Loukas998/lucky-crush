using AutoMapper;
using LuckyCrush.Application.GlobalTypes.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Queries.GetAll;

public class GetAllGlobalQueryHandler(ILogger<GetAllGlobalQueryHandler> logger, IMapper mapper,
    IGlobalTypeRepository globalTypeRepository) : IRequestHandler<GetAllGlobalQuery, Result<IEnumerable<GlobalTypeDto>>>
{
    public async Task<Result<IEnumerable<GlobalTypeDto>>> Handle(GetAllGlobalQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all types");
        var types = await globalTypeRepository.GetAllAsync();
        var results = mapper.Map<IEnumerable<GlobalTypeDto>>(types);
        return Result<IEnumerable<GlobalTypeDto>>.Success(results);
    }
}
