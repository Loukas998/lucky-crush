using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.Wheels.Commands.Update;

public class UpdateWheelCommandHandler(ILogger<UpdateWheelCommandHandler> logger,
    IWheelRepository wheelRepository, IMapper mapper) : IRequestHandler<UpdateWheelCommand>
{
    public async Task Handle(UpdateWheelCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating wheel of id: {Id} with {@Wheel}", request.WheelId, request);
        var existing = await wheelRepository.FindByIdAsync(request.WheelId);
        if (existing == null)
        {

        }

        var result = mapper.Map(request, existing);
        await wheelRepository.SaveChangesAsync();
    }
}
