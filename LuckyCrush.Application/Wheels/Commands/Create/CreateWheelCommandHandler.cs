using AutoMapper;
using LuckyCrush.Application.Wheels.Dtos;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.Create;

public class CreateWheelCommandHandler(ILogger<CreateWheelCommandHandler> logger, IMapper mapper,
    IWheelRepository wheelRepository) : IRequestHandler<CreateWheelCommand, Result<WheelDto>>
{
    public async Task<Result<WheelDto>> Handle(CreateWheelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new wheel: {@Wheel}", request);
        var wheel = mapper.Map<Wheel>(request);

        var created = await wheelRepository.AddAsync(wheel);
        var result = mapper.Map<WheelDto>(created);
        return Result<WheelDto>.Success(result);
    }
}
