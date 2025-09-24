using AutoMapper;
using LuckyCrush.Application.Wheels.Dtos;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Queries.GetById;

public class GetWheelByIdQueryHandler(ILogger<GetWheelByIdQueryHandler> logger, IMapper mapper,
    IWheelRepository wheelRepository) : IRequestHandler<GetWheelByIdQuery, Result<WheelDto>>
{
    public async Task<Result<WheelDto>> Handle(GetWheelByIdQuery request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Getting wheel with id: {Id}", request.WheelId);
        var wheel = await wheelRepository.FindByIdAsync(request.WheelId);
        if (wheel == null)
        {
            return Result<WheelDto>.Failure("Wheel not found");
        }

        var result = mapper.Map<WheelDto>(wheel);
        return Result<WheelDto>.Success(result);
    }
}
