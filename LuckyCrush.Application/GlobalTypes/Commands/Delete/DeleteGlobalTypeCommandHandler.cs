using AutoMapper;
using LuckyCrush.Domain.Repositories;
using MediatR;
using Microsoft.Extensions.Logging;

namespace LuckyCrush.Application.GlobalTypes.Commands.Delete;

public class DeleteGlobalTypeCommandHandler(ILogger<DeleteGlobalTypeCommandHandler> logger, IMapper mapper,
    IGlobalTypeRepository globalTypeRepository) : IRequestHandler<DeleteGlobalTypeCommand>
{
    public async Task Handle(DeleteGlobalTypeCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation(@"Deleting type with id: {GlobalTypeId}: ", request.GlobalTypeId);
        var existing = await globalTypeRepository.FindByIdAsync(request.GlobalTypeId);
        if (existing != null)
        {

        }

        await globalTypeRepository.DeleteAsync(existing);
    }
}
