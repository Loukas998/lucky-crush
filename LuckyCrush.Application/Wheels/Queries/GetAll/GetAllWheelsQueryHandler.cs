using AutoMapper;
using LuckyCrush.Application.Wheels.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Queries.GetAll;

public class GetAllWheelsQueryHandler(ILogger<GetAllWheelsQueryHandler> logger, IMapper mapper,
    IWheelRepository wheelRepository) : IRequestHandler<GetAllWheelsQuery, Result<IEnumerable<WheelDto>>>
{
    public async Task<Result<IEnumerable<WheelDto>>> Handle(GetAllWheelsQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting all wheels");
        var wheels = await wheelRepository.GetAllAsync();

        var results = mapper.Map<IEnumerable<WheelDto>>(wheels);
        return Result<IEnumerable<WheelDto>>.Success(results);
    }
}
