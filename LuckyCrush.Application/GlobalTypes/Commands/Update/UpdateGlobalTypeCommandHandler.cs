using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Commands.Update;

public class UpdateGlobalTypeCommandHandler(ILogger<UpdateGlobalTypeCommandHandler> logger, IMapper maper,
    IGlobalTypeRepository globalTypeRepository) : IRequestHandler<UpdateGlobalTypeCommand>
{
    public async Task Handle(UpdateGlobalTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Updating Restaurant with id: {GlobalTypeId} with {@UpdateGlobalType}", request.GlobalTypeId, request);
        var existing = await globalTypeRepository.FindByIdAsync(request.GlobalTypeId);
        if (existing != null)
        {

        }

        maper.Map(request, existing);
        await globalTypeRepository.SaveChangesAsync();
    }
}
