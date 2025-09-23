using AutoMapper;
using LuckyCrush.Domain.Entities.Wheels;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.Create;

public class CreateWheelCommandHandler(ILogger<CreateWheelCommandHandler> logger, IMapper mapper,
    IWheelRepository wheelRepository) : IRequestHandler<CreateWheelCommand, int>
{
    public async Task<int> Handle(CreateWheelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Creating new wheel: {@Wheel}", request);
        var wheel = mapper.Map<Wheel>(request);

        var created = await wheelRepository.AddAsync(wheel);
        return created.Id;
    }
}
