using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using LuckyCrush.Domain.Response;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.Create;

public class CreateWheelCommandHandler(ILogger<CreateWheelCommandHandler> logger, IMapper mapper,
    IWheelRepository wheelRepository) : IRequestHandler<CreateWheelCommand, Result<int>>
{
    public async Task<Result<int>> Handle(CreateWheelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new wheel: {@Wheel}", request);
        var wheel = mapper.Map<Wheel>(request);

        var created = await wheelRepository.AddAsync(wheel);
        return Result<int>.Success(created.Id);
    }
}
